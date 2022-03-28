using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelDataReader.Models
{
    public class Employee
    {
        
        public int EmployeeId { get; set; }
        //[ForeignKey("OrganisationId")]
        //public Organisation Organisation { get; set; }
        public string OrganisationNumber{ get; set; }
        
        public string FirstName { get; set; }
      
        public string LastName { get; set; }

        public Organisation Organisation { get; set; }
    }
}
