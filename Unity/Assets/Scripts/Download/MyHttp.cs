using System.IO;
using System.Net;
using System.Threading;
public class MyHttp
{
    /// <summary>
    /// 下载进度(百分比)
    /// </summary>
    public float progress { get; private set; }
	public float totalLength;
    private bool isStop;
    private Thread thread;
    /// <summary>
    /// 下载文件(断点续传)
    /// </summary>
    /// <param name="_url">下载地址</param>
    /// <param name="_filePath">本地文件存储目录</param>
    public void Download(string _url, string _fileDirectory)
    {
        isStop = false;
        thread = new Thread(delegate ()
        {
            if (!Directory.Exists(_fileDirectory))
            Directory.CreateDirectory(_fileDirectory);
            string filePath = _fileDirectory + "/" + _url.Substring(_url.LastIndexOf('/') + 1);
            FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);//这一句如果有这个路径，就不创建了然后打开，如果没有就创建然后打开。
            long fileLength = fileStream.Length;
            totalLength = GetLength(_url);
            	// if (fileLength < totalLength)
            	// {
                // 	HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(_url);
                // 	request.AddRange((int)fileLength);
               	//  	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
               	//  	fileStream.Seek(fileLength, SeekOrigin.Begin);
                // 	Stream httpStream = response.GetResponseStream();
				// 	byte[] buffer = new byte[1024];
                // 	int length = httpStream.Read(buffer, 0, buffer.Length);				
                // 	while (length > 0)
                // 	{
                //     	if (isStop)
                //         	break;
                //     	fileStream.Write(buffer, 0, length);
                //     	fileLength += length;
                //     	progress = fileLength / totalLength * 100;
                //     	fileStream.Flush();
                //     	length = httpStream.Read(buffer, 0, buffer.Length);
                // 	}
                // 	httpStream.Close();
                // 	httpStream.Dispose();
            	// }
				// else{
				// 		progress = fileLength / totalLength * 100;
				// }       
            fileStream.Close();
            fileStream.Dispose();
        });
        thread.IsBackground = true;
        thread.Start();
    }
    /// <summary>
    /// 关闭线程
    /// </summary>
    public void Close()
    {
        isStop = true;
    }
    long GetLength(string _fileUrl)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(_fileUrl);
        request.Method = "HEAD";
        HttpWebResponse res = (HttpWebResponse)request.GetResponse();
        return res.ContentLength;
    }
}