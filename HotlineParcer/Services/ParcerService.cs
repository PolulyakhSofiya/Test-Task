using HotlineParcer.Data;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HotlineParcer.Services
{
  public class ParcerService
  {
    public IList<Product> GetProducts(Stream stream, int productCount = 15)
    {
      IList<Product> products = new List<Product>();
      HtmlDocument doc = new HtmlDocument();

      doc.Load(stream);

      HtmlNode[] names = doc.DocumentNode.SelectNodes("//ul[@class='products-list cell-list']/li[@class]/div[@class='item-info']/div[@class='info-description']/p[@class='h4']").ToArray();
      HtmlNode[] images = doc.DocumentNode.SelectNodes("//ul[@class='products-list cell-list']/li[@class]/div[@class='item-img']/a/img[@class='img-product busy']").ToArray();

      for (int i = 0; i < productCount; i++)
      {
        Product product = new Product();

        product.Name = names[i].InnerText.Trim();
        product.ImageUrl = string.Format("http://hotline.ua{0}", images[i].Attributes.FirstOrDefault(a => a.Name == "src")?.Value);
        products.Add(product);
      }

      return products;
    }
  }
}
