using ServerOne.Models;
using ServerOne.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerOne.Controllers
{
    public class CityController : ApiController
    {
        private static List<City> _cities = new List<City>()
        {
            new City(1, "Lahore"),
            new City(2, "Pathokhi"),
            new City(3, "Shahdara"),
            new City(4, "Gojra"),
            new City(5, "Faisalabad"),
            new City(6, "Jhang"),
            new City(7, "Kalam"),
        };

        // GET api/values
        public IEnumerable<City> Get()
        {
            return _cities;
        }

        // GET api/values/5
        public City Get(int id)
        {
            if (id < 1)
            {
                throw new Exception("Invalid identifier");
            }

            var city = _cities.Find(x => x.ID == id);
            if (city == null)
            {
                throw new Exception("No record exists with given identifier");
            }

            return city;
        }

        // POST api/values
        public City Post([FromBody] City value)
        {
            if (value == null)
            {
                throw new Exception("No content received");
            }

            if (value.ID != 0)
            {
                throw new Exception("Invalid action, try PUT.");
            }

            var validator = new CityValidator();
            validator.ValidateOrThrow(value);

            value.ID = _cities.Max(x => x.ID) + 1;
            _cities.Add(value);

            return value;
        }

        // PUT api/values/5
        public City Put(int id, [FromBody] City value)
        {
            if (value == null)
            {
                throw new Exception("No content received");
            }

            if (id <= 0 || value.ID != id || value.ID <= 0)
            {
                throw new Exception("Invalid identifier/action, try POST.");
            }

            var validator = new CityValidator();
            validator.ValidateOrThrow(value);

            var city = _cities.Find(x => x.ID == id);
            if (city == null)
            {
                throw new Exception("No record exists with given identifier");
            }

            city.Name = value.Name;
            return city;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new Exception("Invalid identifier");
            }

            var city = _cities.Find(x => x.ID == id);
            if (city == null)
            {
                throw new Exception("No record exists with given identifier");
            }

            _cities.Remove(city);
        }


    }
}
