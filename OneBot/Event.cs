using System.Text.Json;
using Qotion.OneBot.General;
using File = Qotion.OneBot.General.File;

namespace Qotion.OneBot.Event;

/// <summary>
/// 私聊消息
/// </summary>
public class PrivateMessage:Message
{
    public long target_id { get; set; }
}

/// <summary>
/// 群消息
/// </summary>
public class GroupMessage:Message
{
    public long group_id { get; set; }
    public Anonymous anonymous { get; set; }
}

/// <summary>
/// 加好友请求
/// </summary>
public class FriendRequest:Request {}

/// <summary>
/// 加群请求/邀请
/// </summary>
public class GroupRequest:Request
{
    public string sub_type { get; set; }
    public long group_id { get; set; }
}

/// <summary>
/// 好友戳一戳
/// </summary>
public class FriendNotify:Notice
{
    public string sub_type { get; set; }
    public long sender_id { get; set; }
    public long target_id { get; set; }
}

/// <summary>
/// 群内戳一戳
/// </summary>
public class GroupNotify:Notice
{
    public string sub_type { get; set; }
    public long group_id { get; set; }
    public long target_id { get; set; }
}

/// <summary>
/// 接收到离线文件
/// </summary>
public class OfflineFile:Notice
{
    public File file { get; set; }
}

/// <summary>
/// 其他客户端在线状态变更
/// </summary>
public class OtherClientStatusChanged:Notice
{
    public Device client { get; set; }
    public bool online { get; set; }
}

/// <summary>
/// 消息事件
/// </summary>
public class Message : Base
{
    public int font { get; set; }
    public string message_type { get; set; }
    public string sub_type { get; set; }
    public int message_id { get; set; }
    public string message { get; set; }
    public string raw_message { get; set; }
    public Sender sender { get; set; }
}

/// <summary>
/// 通知事件
/// </summary>
public class Notice : Base
{
    public string notice_type { get; set; }
}

/// <summary>
/// 请求事件
/// </summary>
public class Request : Base
{
    public string request_type { get; set; }
    public string comment { get; set; }
    public string flag { get; set; }
}

/// <summary>
/// 基础事件
/// </summary>
public class Base
{
    public string post_type { get; set; }
    public long self_id { get; set; }
    public int time { get; set; }
    public long user_id { get; set; }
}