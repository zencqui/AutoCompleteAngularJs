using AngularJsAutocomplete.Business.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAutocomplete.Business.Services
{
    public class JsonToPocoParserService : IJsonToPocoParserService
    {
        public IEnumerable<Make> Parse(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                dynamic jsonObject = JObject.Parse(json);
                JArray jMakes = jsonObject.makes as JArray;
                List<Make> makes = new List<Make>();

                if (jMakes != null)
                {
                    foreach (JObject jmake in jMakes)
                    {
                        var make = new Make();
                        make.Id = int.Parse((string)jmake["id"]);
                        make.Name = (string)jmake["name"];
                        make.NiceName = (string)jmake["niceName"];

                        JArray jModels = jmake["models"] as JArray;

                        foreach (JObject jmodel in jModels)
                        {
                            var model = new Model();
                            model.Id = (string)jmodel["id"];
                            model.Make = make;
                            model.MakeId = make.Id;
                            model.Name = (string)jmodel["name"];
                            model.NiceName = (string)jmodel["niceName"];

                            JArray jYears = jmodel["years"] as JArray;

                            foreach (var jYear in jYears)
                            {
                                int yearId = int.Parse((string)jYear["id"]);

                                // cannot insert duplicate id in db
                                if (yearId == int.Parse("200691942") 
                                    || yearId == int.Parse("200728424")
                                    || yearId == int.Parse("200781954")
                                    || yearId == int.Parse("401627328")
                                    || yearId == int.Parse("401628158")
                                    || yearId == int.Parse("401628159")
                                    || yearId == int.Parse("401628160")
                                    || yearId == int.Parse("401630246"))
                                {
                                    continue;
                                }

                                var year = new Year();
                                year.Id = yearId; // int.Parse((string)jYear["id"]);
                                year.Years = int.Parse((string)jYear["year"]);
                                year.Model = model;
                                year.ModelId = model.Id;

                                model.Years.Add(year);
                            }
                            make.Models.Add(model);
                        }
                        makes.Add(make);
                    }
                }

                return makes;
            }
            return null;
        }
    }
}
