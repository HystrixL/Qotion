using System.Text.Json;

namespace Qotion.OneBot.Request;

class Request<T>
{
    public Request(string action, T @params)
    {
        this.action = action;
        __params = @params;
    }

    public string action { get; set; }
    public T __params { get; set; }
}

static class Request
{
    public static string Serialize<T>(Request<T> request)
    {
        var requestJson = JsonSerializer.Serialize(request);
        requestJson = requestJson.Replace("__params", "params");
        return requestJson;
    }
}