namespace Qotion.OneBot.General;

/// <summary>
/// 发送人
/// </summary>
public class Sender
{
    public int age { get; set; }
    public string nickname { get; set; }
    public string sex { get; set; }
    public long user_id { get; set; }
}

/// <summary>
/// 匿名信息
/// </summary>
public class Anonymous
{
    public long id { get; set; }
    public string name { get; set; }
    public string flag { get; set; }
}

/// <summary>
/// 文件
/// </summary>
public class File
{
    public string name { get; set; }
    public long size { get; set; }
    public string url { get; set; }
}

/// <summary>
/// 设备
/// </summary>
public class Device
{
    public long app_id { get; set; }
    public string device_name { get; set; }
    public string device_kind { get; set; }
}
