using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Qotion.Client;
using Qotion.Notion;
using OntBotAPI = Qotion.OneBot.API;
using OneBotEvent =  Qotion.OneBot.Event;
using OneBotRequest = Qotion.OneBot.Request;
using OneBotResponse = Qotion.OneBot.Response;

string secret = "";

void GetSecret()
{
    if (File.Exists(".\\secret.txt"))
    {
        secret = File.ReadAllText(".\\secret.txt");
    }
    else File.Create(".\\secret.txt");
    if (secret != "") return;
    
    Console.WriteLine("Please Enter Your Notion API Token in secret.txt");
    Environment.Exit(0);
}


void WebSocketExample()
{
    Console.WriteLine("Please enter your account:");
    var account = Int64.Parse(Console.ReadLine() ?? string.Empty);
    Console.WriteLine("Please enter the cqhttp port:");
    var port = Console.ReadLine();
    
    WebSocket wsEvent = new WebSocket($"ws://127.0.0.1:{port}/event");
    WebSocket wsApi = new WebSocket($"ws://127.0.0.1:{port}/api");
    wsEvent.OnMessage += ReceivedMessage;
    wsEvent.Open();
    
    void ReceivedMessage(object sender, string data)
    {
        Console.WriteLine("received:"+data);
        var json = JsonNode.Parse(data);
        var postType = json["post_type"].ToString();
        if(postType!="message") return;
        var messageType = json["message_type"].ToString();
        if(messageType!="private") return;
        var privateMessage = OneBotResponse.Response.Convert<OneBotEvent.PrivateMessage>(data);
        var message = new OntBotAPI.SendMessage("private", account, 0, $"你发送的信息是{privateMessage.message}，现在是{DateTime.Now}。信息自动处理完成。", true);
        var request = new OneBotRequest.Request<OntBotAPI.SendMessage>("send_private_msg",message);
        wsApi.OnMessage += (o, s) => Console.WriteLine(s);
        wsApi.Open();
        var requestJson = OneBotRequest.Request.Serialize(request);
        Console.WriteLine("send:"+requestJson);
        wsApi.Send(requestJson);
    }
}

void NotionAPIExample()
{
    JsonSerializer.Deserialize<Object>(
        "{\"parent\":{\"type\":\"page_id\",\"page_id\":\"d9b6094e-cc20-4bae-ba36-ef63c829fb9d\"},\"properties\":{\"title\":{\"id\":\"title\",\"type\":\"title\",\"title\":[{\"type\": \"text\",\"text\": {\"content\": \"Created By Qotion using C#\"}}]}}}");

    var result = Http.GetHttpResponse("https://api.notion.com/v1/pages/0390028bb9d04ae29065495907db034c",secret);
    Console.WriteLine(result);
    
    /*
    void retrieve()
    {
        var client = new RestClient("https://api.notion.com/v1/pages/0390028bb9d04ae29065495907db034c");
        var request = new RestRequest { Method = Method.Get};
        request.AddHeader("Accept", "application/json");
        request.AddHeader("Authorization", "Bearer secret_KN7qL2RFIWHEhFT8kZbNoe07xCjqXK25X05xhSL6DSc");
        request.AddHeader("Notion-Version", "2022-02-22");
        var response = client.ExecuteAsync(request).Result;
        Console.WriteLine(response);
    }
    
    
    void create()
    {
        var client = new RestClient("https://api.notion.com/v1/pages");
            var request = new RestRequest { Method = Method.Post };
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer secret_KN7qL2RFIWHEhFT8kZbNoe07xCjqXK25X05xhSL6DSc");
            request.AddHeader("Notion-Version", "2021-08-16");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("",
                @"{""parent"":{""type"":""page_id"",""page_id"":""d9b6094e-cc20-4bae-ba36-ef63c829fb9d""},
""properties"":{""title"":{""id"":""title"",""type"":""title"",""title"":[{""type"": ""text"",""text"":
 {""content"": ""Created By Qotion using C#""}}]}}}",
                ParameterType.RequestBody, false);
            var result =  client.ExecuteAsync(request).Result;
            Console.WriteLine(result.Content);
    }
    */
}

GetSecret();
NotionAPIExample();

Console.ReadLine();
