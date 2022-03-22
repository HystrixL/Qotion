using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Qotion;
using Qotion.Client;
using Qotion.OneBot;
using Qotion.OneBot.API;
using Qotion.OneBot.Event;

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
    var privateMessage = Event.Convert<PrivateMessageEvent>(data);
    var message = new SendMessage("private", account, 0, $"你发送的信息是{privateMessage.message}，现在是{DateTime.Now}。信息自动处理完成。", true);
    var request = new Request<SendMessage>("send_private_msg",message);
    wsApi.OnMessage += (o, s) => Console.WriteLine(s);
    wsApi.Open();
    var requestJson = JsonSerializer.Serialize(request);
    requestJson = requestJson.Replace("_params", "params");
    Console.WriteLine("send:"+requestJson);
    wsApi.Send(requestJson);
}