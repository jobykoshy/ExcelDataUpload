using ExcelDataReader.Models;
using ExcelDataReader.Services;
using ExcelDataReaderWebApi.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelDataReaderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelDataController : ControllerBase
    {
        public ILogger _logger;
        private IExcelDataService _service;

        public ExcelDataController(ILogger<ExcelDataController> logger, IExcelDataService excelDataService)
        {
            _logger = logger;
            _service = excelDataService;

        }

        public IActionResult UploadExcel([FromForm(Name ="file")]IFormFile formFile)
        {
            try
            {
                _service.UploadExcel(formFile);
                return Ok(new { results = "File uploaded successfully" });
            }
            catch(ValidationException ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new { results = ex.Message.ToString() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public List<Organisation> GetOrganisations()
        {
            return _service.GetOrganisations().ToList();
        }

    }

}
