using System.Text.Json;

namespace Qotion.OneBot.Response;

public class Response
{
    public static T Convert<T>(string received)
    {
        // var json = JsonNode.Parse(received);
        // //if (json["post_type"] == null) return null;
        // var postType = json["post_type"].ToString();
        
        var result = JsonSerializer.Deserialize<T>(received);
        return result;
    }
}