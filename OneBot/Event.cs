using System.Text.Json;

namespace Qotion.OneBot.Event;

public class Sender
{
    public int age { get; set; }
    public string nickname { get; set; }
    public string sex { get; set; }
    public long user_id { get; set; }
}

public class Anonymous
{
    public long id { get; set; }
    public string name { get; set; }
    public string flag { get; set; }
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

public class GroupMessage
{
    public long time { get; set; }
    public long self_id { get; set; }
    public string post_type { get; set; }
    public string message_type { get; set; }
    public string sub_type { get; set; }
    public int message_id { get; set; }
    public long group_id { get; set; }
    public long user_id { get; set; }
    public Anonymous anonymous { get; set; }
    public string message { get; set; }
    public string raw_message { get; set; }
    public int font { get; set; }
    public Sender Sender { get; set; }
}

public static class Event
{
    public static T? Convert<T>(string received)
    {
        // var json = JsonNode.Parse(received);
        // //if (json["post_type"] == null) return null;
        // var postType = json["post_type"].ToString();


        var result = JsonSerializer.Deserialize<T>(received);
        return result;
    }
}