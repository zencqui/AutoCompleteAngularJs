using AngularJsAutocomplete.Business.Models;
using AngularJsAutocomplete.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Services;
using System.Web.Services;

namespace AngularJsAutocomplete.Controllers
{
    public class CarApiController : ApiController
    {
        private readonly IEdmundDbRepository edmundDbRepository;

        public CarApiController(IEdmundDbRepository edmundDbRepository)
        {
            this.edmundDbRepository = edmundDbRepository;
        }

        public IEnumerable<Make> GetMakes()
        {
            return this.edmundDbRepository.GetAllMakes();
        }

        public IEnumerable<Model> GetModels()
        {
            return this.edmundDbRepository.GetAllModels();
        }
    }
}
