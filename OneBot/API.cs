namespace Qotion.OneBot.API;

/// <summary>
/// 发送消息
/// </summary>
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

/// <summary>
/// 撤回消息
/// </summary>
public class DeleteMessage
{
    public DeleteMessage(int messageId)
    {
        message_id = messageId;
    }

    public int message_id { get; set; }
}

/// <summary>
/// 处理加好友请求
/// </summary>
public class SetFriendAddRequest
{
    public SetFriendAddRequest(string flag, bool approve, string remark)
    {
        this.flag = flag;
        this.approve = approve;
        this.remark = remark;
    }

    public string flag { get; set; }
    public bool approve { get; set; }
    public string remark { get; set; }
}

/// <summary>
/// 处理加群请求
/// </summary>
public class SetGroupAddRequest
{
    public SetGroupAddRequest(string flag, string subType, string type, bool approve, string reason)
    {
        this.flag = flag;
        sub_type = subType;
        this.type = type;
        this.approve = approve;
        this.reason = reason;
    }

    public string flag { get; set; }
    public string sub_type { get; set; }
    public string type { get; set; }
    public bool approve { get; set; }
    public string reason { get; set; }
}

/// <summary>
/// 获取cqhttp版本信息
/// </summary>
public class GetVersionInfo{}

/// <summary>
/// 重启cqhtp
/// </summary>
public class SetRestart
{
    public SetRestart(int delay)
    {
        this.delay = delay;
    }

    public int delay { get; set; }
}

/// <summary>
/// 获取状态
/// </summary>
public class GetStatus{}

/// <summary>
/// 获取在线客户端列表
/// </summary>
public class GetOnlineClients
{
    public GetOnlineClients(bool noCache)
    {
        no_cache = noCache;
    }

    public bool no_cache { get; set; }
}