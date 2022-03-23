using System;
using System.Collections.Generic;
using System.Net;

string url;

Console.Write("Enter URL: ");
url = Console.ReadLine();

if (String.IsNullOrEmpty(url))
{
    Console.WriteLine("You have not entered a url!");
    return;
}

HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
{
    Console.WriteLine("\r\nHeaders:");
    for (int i = 0; i < response.Headers.Count; ++i)
        Console.WriteLine("Header Name:{0}, Value :{1}", response.Headers.Keys[i], response.Headers[i]);
    string path;
    path = response.Headers["Content-Disposition"];
    string filename;
    if (!String.IsNullOrEmpty(path))
        filename = path.Split(new string[] { "=" }, StringSplitOptions.None)[1];
    else
        filename = Path.GetFileName(url);

    var responseStream = response.GetResponseStream();
    using (var fileStream = File.Create(filename))
    {
        responseStream.CopyTo(fileStream);
    }
}