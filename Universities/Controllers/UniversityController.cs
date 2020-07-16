using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Universities.Models;

namespace Universities.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController : ControllerBase
    {
        [HttpGet]
        public async Task<List<University>> Get()
        {
            var client = new RestClient("http://universities.hipolabs.com/search");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteGetAsync(request);

            if (!response.IsSuccessful)
            {
                string message = "Error making request.  Status code: " + response.StatusCode;
                var exception = new ApplicationException(message);
                throw exception;
            }

            List<University> universityList = (List<University>)JsonConvert.DeserializeObject(response.Content, typeof(List<University>));
            universityList.Sort((x, y) => string.Compare(x.Name, y.Name));

            return universityList;
        }
    }
}
