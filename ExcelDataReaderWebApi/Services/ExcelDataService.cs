using ExcelDataReader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelDataReader.Services
{
    public class ExcelDataService:IExcelDataService
    {
        private readonly OrganisationDbContext organisationDbContext;
        private readonly string _config;
        public ExcelDataService(OrganisationDbContext dbContext,IConfiguration config)
        {
            organisationDbContext = dbContext;
            _config = config.GetConnectionString("AppConnectionString");
        }

        public string UploadExcel(IFormFile postedFile)
        {
            if (postedFile.FileName.Split('.').Last() != "xls" && postedFile.FileName.Split('.').Last() != "xlsx")
                throw new ValidationException("Please send an excel file to upload");

            var ms = new MemoryStream();
            postedFile.CopyTo(ms);
            using (ExcelPackage package = new ExcelPackage(ms))
            {
                
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;
                if (worksheet != null)
                {
                    IList<Organisation> organisations = new List<Organisation>();
                    for (int row = 2; row <= rowCount; row++)
                    {
                        organisations.Add(new Organisation
                        {
                            OrganisationName = (worksheet.Cells[row, 1].Value ?? string.Empty).ToString().Trim(),
                            OrganisationNumber = (worksheet.Cells[row, 2].Value ?? string.Empty).ToString().Trim(),
                            AddressLine1 = (worksheet.Cells[row, 3].Value ?? string.Empty).ToString().Trim(),
                            AddressLine2 = (worksheet.Cells[row, 4].Value ?? string.Empty).ToString().Trim(),
                            AddressLine3 = (worksheet.Cells[row, 5].Value ?? string.Empty).ToString().Trim(),
                            AddressLine4 = (worksheet.Cells[row, 6].Value ?? string.Empty).ToString().Trim(),
                            Town = (worksheet.Cells[row, 7].Value ?? string.Empty).ToString().Trim(),
                            PostCode = (worksheet.Cells[row, 8].Value ?? string.Empty).ToString().Trim(),
                            EmployeeCount = Int32.Parse((worksheet.Cells[row, 9].Value ?? "0").ToString().Trim()),
                        });
                    }
                    organisationDbContext.Add(organisations);
                    organisationDbContext.SaveChanges();
                }

                ExcelWorksheet employeeWorksheet = package.Workbook.Worksheets[0];
                rowCount = employeeWorksheet.Dimension.Rows;
                if (worksheet != null)
                {
                    IList<Employee> employees = new List<Employee>();
                    for (int row = 2; row <= rowCount; row++)
                    {
                        employees.Add(new Employee
                        {
                            OrganisationNumber = (employeeWorksheet.Cells[row, 1].Value ?? string.Empty).ToString().Trim(),
                            FirstName = (employeeWorksheet.Cells[row, 2].Value ?? string.Empty).ToString().Trim(),
                            LastName = (employeeWorksheet.Cells[row, 3].Value ?? string.Empty).ToString().Trim()
                        });
                    }
                    organisationDbContext.Add(employees);
                    organisationDbContext.SaveChanges();
                }

            }
            return "";

        }

        public IEnumerable<Organisation> GetOrganisations()
        {
           return organisationDbContext.Organisations.ToList();
        }
    }
}
