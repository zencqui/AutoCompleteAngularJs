using AngularJsAutocomplete.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAutocomplete.Business.Services
{
    public class EdmundDbRepository : IEdmundDbRepository
    {
        private EdmundsDbEntities edmundDb = new EdmundsDbEntities();

        public EdmundDbRepository()
        {
            this.edmundDb.Configuration.ProxyCreationEnabled = false;
        }

        public int SaveMakes(IEnumerable<Make> makes)
        {
            foreach (var make in makes)
            {
                edmundDb.Makes.Add(make);
            }

            return edmundDb.SaveChanges();
        }

        public IEnumerable<Make> GetAllMakes()
        {
            return edmundDb.Makes;
        }

        public IEnumerable<Model> GetAllModels()
        {
            return edmundDb.Models;
        }
    }
}
