using System;
using LegitHttpClient;

class Program
{
    static void Main()
    {
        Console.Title = "Double Counter Bypass";
        string code = "";

        while (code == "")
        {
            Console.Write("[+] Please, insert a valid Double Counter verification link / code here: ");
            code = Console.ReadLine();

            if (code.StartsWith("https://"))
            {
                code = code.Substring("https://".Length);
            }

            if (code.StartsWith("http://"))
            {
                code = code.Substring("http://".Length);
            }

            if (code.StartsWith("www."))
            {
                code = code.Substring("www.".Length);
            }

            if (code.StartsWith("verify.dcounter.space/v/"))
            {
                code = code.Substring("verify.dcounter.space/v/".Length);
            }

            if (code.Length < 3)
            {
                Console.WriteLine("[+] Inserted link or code is not valid.");
                code = "";
            }
        }

        HttpClient client = new HttpClient();
        client.ConnectTo("verify.dcounter.space", true, 443);

        HttpRequest request = new HttpRequest();
        request.URI = $"/v/{code}";
        request.Version = HttpVersion.HTTP_11;
        request.Method = HttpMethod.GET;
        request.Headers.Add(new HttpHeader() { Name = "Host", Value = "verify.dcounter.space" });
        request.Headers.Add(new HttpHeader() { Name = "Connection", Value = "keep-alive" });
        request.Headers.Add(new HttpHeader() { Name = "sec-ch-ua", Value = "\"Chromium\";v=\"104\", \" Not A;Brand\";v=\"99\", \"Google Chrome\";v=\"104\"" });
        request.Headers.Add(new HttpHeader() { Name = "sec-ch-ua-mobile", Value = "?0" });
        request.Headers.Add(new HttpHeader() { Name = "sec-ch-ua-platform", Value = "\"Windows\"" });
        request.Headers.Add(new HttpHeader() { Name = "Upgrade-Insecure-Requests", Value = "1" });
        request.Headers.Add(new HttpHeader() { Name = "User-Agent", Value = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36" });
        request.Headers.Add(new HttpHeader() { Name = "Accept", Value = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9" });
        request.Headers.Add(new HttpHeader() { Name = "Sec-Fetch-Site", Value = "none" });
        request.Headers.Add(new HttpHeader() { Name = "Sec-Fetch-Mode", Value = "navigate" });
        request.Headers.Add(new HttpHeader() { Name = "Sec-Fetch-User", Value = "?1" });
        request.Headers.Add(new HttpHeader() { Name = "Sec-Fetch-Dest", Value = "document" });
        request.Headers.Add(new HttpHeader() { Name = "Accept-Encoding", Value = "gzip, deflate, br" });
        request.Headers.Add(new HttpHeader() { Name = "Accept-Language", Value = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7" });

        client.Send(request);
        Console.WriteLine("[+] Succesfully bypassed Double Counter.");
        Console.ReadLine();
    }
}