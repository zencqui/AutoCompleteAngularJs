using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAutocomplete.Business.Services
{
    public class ProductService : IProductService
    {
        private TrialsDBEntities db = new TrialsDBEntities();

        public IEnumerable<Product> GetProducts()
        {
            return db.Products;
        }
    }
}
