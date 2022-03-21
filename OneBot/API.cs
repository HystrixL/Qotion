using System.Text.Json;
using System.Text.Json.Nodes;

namespace Qotion.OneBot;

public class API
{
    public class Sender
    {
        public int age {get;set;}
        public string nickname {get;set;}
        public string sex { get; set; }
        public long user_id { get; set; }
    }
    
    public class PrivateMessage
    {
        public int font { get; set; }
        public string message { get; set; }
        public long message_id { get; set; }
        public string message_type { get; set; }
        public string post_type { get; set; }
        public string raw_message { get; set; }
        public long self_id { get; set; }
        public Sender sender { get; set; }
        public string sub_type { get; set; }
        public long target_id { get; set; }
        public int time { get; set; }
        public long user_id { get; set; }
    }

    public static T? Convert<T>(string received)
    {
        var json = JsonNode.Parse(received);
        //if (json["post_type"] == null) return null;
        var postType = json["post_type"].ToString();


        var result = JsonSerializer.Deserialize<T>(received);
        return result;
    }
}