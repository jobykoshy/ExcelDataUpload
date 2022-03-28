using ExcelDataReader.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelDataReader.Services
{
    public interface IExcelDataService
    {
        
        public string UploadExcel(IFormFile postedFile);

        public IEnumerable<Organisation> GetOrganisations();

    }
}
