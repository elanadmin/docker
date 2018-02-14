using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HostApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        public ProductController()
        {

        }

        [HttpGet]
        public IEnumerable<string> GetList()
        {
            return new string[] { "product1" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "product1";
        }

    }
}