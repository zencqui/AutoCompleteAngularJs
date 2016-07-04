using AngularJsAutocomplete.Business;
using AngularJsAutocomplete.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularJsAutocomplete.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.productService.GetProducts();
        }
    }
}
