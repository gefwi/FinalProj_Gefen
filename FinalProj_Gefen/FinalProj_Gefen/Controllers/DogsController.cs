using FinalProj_Gefen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace FinalProj_Gefen.Controllers
{
    public class DogsController : ApiController
    { // GET api/<controller>
        public List<Dogs> Get()
        {
            /*
            Flight flight = new Flight();
            List<Flight> fList = flight.Read();
            return fList;
            */
            return null;
        }

        public List<Dogs> Get(string breed, string name,string image, string city)
        {
            return null;
        }

        // GET api/<controller>/5
        public List<Dogs> Get(string city)
        {
            Dogs f = new Dogs();
            return f.getByCity(city);
        }

        // POST api/<controller>
        public void Post([FromBody] Dogs dog)
        {
           dog.Insert();
       
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        }
    }
