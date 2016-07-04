using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAutocomplete.Business.Services
{
    public class EdmundApiService : IEdmundApiService
    {
        private string edmundCarMakesApi = "https://api.edmunds.com/api/vehicle/v2/makes?api_key=8ygetqdnk9qh63xyenpn73u7";

        public string GetMakes()
        {
            WebRequest request = WebRequest.Create(edmundCarMakesApi);
            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            StreamReader rdr = new StreamReader(stream);

            string result = rdr.ReadToEnd();

            rdr.Close();
            response.Close();

            return result;

        }
    }
}
