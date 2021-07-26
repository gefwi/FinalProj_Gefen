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

        public List<Dogs> Get(string breed, string name)
        {
            return null;
        }

        // GET api/<controller>/5
        public List<Dogs> Get(double maxPrice)
        {
            Dogs f = new Dogs();
            return f.getByMaxPrice(maxPrice);
            // DataReader class ex - Add Your code Here


        }

        // POST api/<controller>
        public void Post([FromBody] Dogs dog)
        {
            dog.Insert();
            //return flight;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            // TODO:
            // create a new object of type Flight
            Dogs f = new Dogs();
            int num = f.Delete(id);
            if (num == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "id: " + id + " does not exist");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "sababa");
            }
            // call the delete method of flight
            // return a message object

        }
    }
}