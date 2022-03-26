using System.Net;
using System.Text;

namespace Qotion.Notion;

public class Http
{
    public static string PostHttpRequest(string url, string content,string secret)
    {
        var result = "";

        try
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/json";
            req.Headers.Add("Accept", "application/json");
            req.Headers.Add("Authorization", "Bearer "+secret);
            req.Headers.Add("Notion-Version", "2022-02-22");
    
            var data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            using (var reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }

            var resp = (HttpWebResponse)req.GetResponse();
            var stream = resp.GetResponseStream();
            //获取响应内容
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
                reader.Close();
            }
            stream.Close();
            resp.Close();
            req.Abort();
        }
        catch (WebException e)
        {
            result = e.Message;
        }

        return result;
    }
    
    public static string GetHttpResponse(string url,string secret)
    {
        string retString = "";

        try
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", "Bearer "+secret);
            request.Headers.Add("Notion-Version", "2022-02-22");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            response.Close();
        }
        catch (WebException e)
        {
            retString = e.Message;
        }

        return retString;
    }
}