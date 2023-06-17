using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Api;

public class ProductsGet
{
   readonly IProductData productData;
   public ProductsGet(IProductData productData)
    {
        this.productData = productData;
    }

    [FunctionName("ProductsGet")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products" )]
        HttpRequest req)
    {
        var products = await productData.GetProducts();

        return new OkObjectResult(products);
    }
}

