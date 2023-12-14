using ServerOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerOne.Validators
{
    public class CityValidator
    {
        public bool ValidateOrThrow(City city)
        {
            if (city == null)
            {
                throw new Exception("Value of city cannot be null");
            }
            
            if (string.IsNullOrWhiteSpace(city.Name))
            {
                throw new Exception("Name of city cannot be null");
            }

            return true;
        }
    }
}