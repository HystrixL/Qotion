using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Qotion;
using Qotion.Client;
using Qotion.OneBot;
using OntBotAPI = Qotion.OneBot.API;
using OneBotEvent =  Qotion.OneBot.Event;
using OneBotRequest = Qotion.OneBot.Request;
using OneBotResponse = Qotion.OneBot.Response;

Console.WriteLine("Please enter your account:");
var account = Int64.Parse(Console.ReadLine() ?? string.Empty);
Console.WriteLine("Please enter the cqhttp port:");
var port = Console.ReadLine();

WebSocket wsEvent = new WebSocket($"ws://127.0.0.1:{port}/event");
WebSocket wsApi = new WebSocket($"ws://127.0.0.1:{port}/api");
wsEvent.OnMessage += ReceivedMessage;
wsEvent.Open();

Console.ReadLine();

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