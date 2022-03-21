using System.Text.Json;
using System.Text.Json.Nodes;

namespace Qotion.OneBot;

public class API
{
    public class SendMessage
    {
        public SendMessage(string messageType, long userId, long groupId, string message, bool autoEscape)
        {
            message_type = messageType;
            user_id = userId;
            group_id = groupId;
            this.message = message;
            auto_escape = autoEscape;
        }

        public string message_type { get; set; }
        public long user_id { get; set; }
        public long group_id { get; set; }
        public string message { get; set; }
        public bool auto_escape { get; set; }
    
    }
}