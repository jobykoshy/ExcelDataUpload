using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelDataReader.Models
{
    public class Organisation
    {
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
    //    public int OrganisationId { get; set; }

    //    [Required]
    //    [MaxLength(250)]
    //    public string OrganisationName{ get; set; }
    //    [Required]
    //    [MaxLength(250)]
    //    public string OrganisationNumber { get; set; }
    //    public Address OrganisationAddress { get; set; }
    //    public int EmployeeCount { get; set; }


    
    public int OrganisationId { get; set; }

   
    public string OrganisationName { get; set; }
   
    public string OrganisationNumber { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public string AddressLine4 { get; set; }
    public string Town { get; set; }
    public string PostCode { get; set; }
    public int EmployeeCount { get; set; }

    public ICollection<Employee> Employees{ get; set; }


    }
}
