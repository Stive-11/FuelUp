using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuelUp.Models.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FuelUp.Api
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {
        // api/test/JsonConvert
        [HttpPost("JsonConvert")]
        public IActionResult Post1()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var person = new Person() {name = "John", age = 25};
            var returnString = JsonConvert.SerializeObject(person);
            return Ok(returnString);
        }

        // api/test/simple
        [HttpPost("simple")]
        public IActionResult Post2()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var person = new Person() { name = "John", age = 25 };
           
            return Ok(person);
        }
        private class Person
        {
            public string name { set; get; }
            public int age { set; get; }
        }
    }
}