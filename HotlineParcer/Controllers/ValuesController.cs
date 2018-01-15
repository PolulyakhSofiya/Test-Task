using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HotlineParcer.Data;
using HotlineParcer.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotlineParcer.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    private readonly Context context;
    private readonly HttpService httpService;

    public ValuesController(Context context)
    {
      this.context = context;
      this.httpService = new HttpService();
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      Stream stream = await this.httpService.GetPage();
      IEnumerable<Product> products = new ParcerService().GetProducts(stream);

      if (!this.context.Products.Any())
      {
        foreach (Product product in products)
        {
          this.context.Products.Add(product);
        }

        this.context.SaveChanges();
      }

      return this.View(products);
    }
  }
}
