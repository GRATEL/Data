using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

   namespace api.Models
{
    public class Person
    {
        public int Id {get; set;}
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
    }
}