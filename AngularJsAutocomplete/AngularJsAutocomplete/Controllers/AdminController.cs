using AngularJsAutocomplete.Business.Models;
using AngularJsAutocomplete.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJsAutocomplete.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEdmundApiService edmundService;
        private readonly IJsonToPocoParserService jsonService;
        private readonly IEdmundDbRepository edmundRepository;
        

        public AdminController(IEdmundApiService edmundService,
            IJsonToPocoParserService jsonService,
            IEdmundDbRepository edmundRepository)
        {
            this.edmundService = edmundService;
            this.jsonService = jsonService;
            this.edmundRepository = edmundRepository;
        }

        public ActionResult Index()
        {
            string result = edmundService.GetMakes();

            if(!string.IsNullOrEmpty(result))
            {
                var makes = jsonService.Parse(result);

                if (makes != null)
                {
                    this.edmundRepository.SaveMakes(makes);
                }
            }

            return View();
        }

    }
}
