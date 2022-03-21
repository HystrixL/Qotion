using System.Text.Json;
using System.Text.Json.Serialization;
using Qotion;
using Qotion.Client;
using Qotion.OneBot;

WebSocket wsEvent = new WebSocket("ws://127.0.0.1:6789/event");
WebSocket wsApi = new WebSocket("ws://127.0.0.1:6789/api");
wsEvent.OnMessage += ReceivedMessage;
wsEvent.Open();

Console.ReadLine();

void ReceivedMessage(object sender, string data)
{
    var privateMessage = Event.Convert<Event.PrivateMessage>(data);
    if (privateMessage != null)
    {
        Console.WriteLine(privateMessage.message);
        var message = new API.SendMessage("private", 3033619778, 0, $"你发送的信息是{privateMessage.message}，现在是{DateTime.Now}。信息自动处理完成。", true);
        var request = new Request<API.SendMessage>("send_private_msg",message);
        wsApi.OnMessage += (o, s) => Console.WriteLine(s);
        wsApi.Open();
        var requestJson = JsonSerializer.Serialize(request);
        requestJson = requestJson.Replace("_params", "params");
        Console.WriteLine(requestJson);
        wsApi.Send(requestJson);
    }
}

class Request<T>
{
    public Request(string action, T @params)
    {
        this.action = action;
        _params = @params;
    }

    public string action { get; set; }
    public T _params { get; set; }
}