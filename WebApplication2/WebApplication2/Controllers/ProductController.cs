using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Linq;
using Models;

[ApiController]
[Route("")]
public class ProductController : ControllerBase
{
    private readonly List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Product A", Color = "Red" },
        new Product { Id = 2, Name = "Product B", Color = "Blue" },
        new Product { Id = 3, Name = "Product C", Color = "Red" },
        new Product { Id = 4, Name = "Product D", Color = "Green" },
        new Product { Id = 5, Name = "Product E", Color = "Red" },
    };

    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [HttpGet("api/products/bycolor")]
    public IActionResult GetProductsByColor([FromQuery] string color)
    {
        // Filter products by color
        var filteredProducts = _products.Where(product => product.Color.Equals(color, System.StringComparison.OrdinalIgnoreCase)).ToList();

        if (filteredProducts.Count == 0)
        {
            return NotFound("No products found with the specified color.");
        }

        return Ok(filteredProducts);
    }

    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [HttpGet("api/products")]
    public IActionResult GetProducts()
    {

        return Ok(_products);
    }


    [HttpGet("")]
    public IActionResult GetHealthCheck()
    {

        return Ok("OK");
    }
}