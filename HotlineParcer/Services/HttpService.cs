using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotlineParcer.Services
{
  public class HttpService
  {
    public async Task<Stream> GetPage()
    {
      Uri baseAddress = new Uri("http://hotline.ua/computer/noutbuki-netbuki/883-85763-85764-85765-385943/");
      CookieContainer cookieContainer = new CookieContainer();

      cookieContainer.Add(baseAddress, new Cookie("gd_order", "0"));

      HttpClient client = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer });
      HttpResponseMessage result = client.GetAsync(baseAddress).Result;

      return await result.Content.ReadAsStreamAsync();
    }
  }
}
