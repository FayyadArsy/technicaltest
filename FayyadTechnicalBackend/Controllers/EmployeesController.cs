using FayyadTechnicalBackend.Models;
using FayyadTechnicalBackend.Repository;
using FayyadTechnicalBackend.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace FayyadTechnicalBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesRepository repository; 
        public EmployeesController(EmployeesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var allData = repository.Get();
            return Ok(new { status = HttpStatusCode.OK, message = "Menampilkan Seluruh Data", allData });
        }
        [HttpPost]
        public virtual ActionResult Insert(EmployeesVM insert)
        {
           try{
                repository.Insert(insert);
                return Ok(new { status = HttpStatusCode.OK, message = "Data Inserted"});
           }
           catch (Exception e){
                return BadRequest(new { status = HttpStatusCode.OK, message = "Insert Employee Failed", });
           }
        }
        [HttpPut("{Id}")]
        public virtual ActionResult Update(Employees employees)
        {
            try{
                var update = repository.Update(employees);
                if (update == null){
                    return NotFound(new { status =  HttpStatusCode.NotFound, message = "Data Not Found", });
                }
                return Ok(new { status = HttpStatusCode.OK, message = "Data Updated" });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = HttpStatusCode.OK, message = "Update Employee Failed", });
            }
        }
    }
}

   