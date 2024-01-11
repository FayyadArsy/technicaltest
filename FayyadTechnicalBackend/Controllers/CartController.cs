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
    public class CartController : ControllerBase
    {
        private readonly CartRepository repository; 
        public CartController(CartRepository repository)
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
        public virtual ActionResult Insert(CartVm insert)
        {
           try{
                repository.Insert(insert);
                return Ok(new { status = HttpStatusCode.OK, message = "Data Inserted"});
           }
           catch (Exception e){
                return BadRequest(new { status = HttpStatusCode.OK, message = "Insert Failed", });
           }
        }
        [HttpPut("{Id}")]
        public virtual ActionResult Update(Cart Cart)
        {
            try{
                var update = repository.Update(Cart);
                if (update == null){
                    return NotFound(new { status =  HttpStatusCode.NotFound, message = "Data Not Found", });
                }
                return Ok(new { status = HttpStatusCode.OK, message = "Data Updated" });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = HttpStatusCode.OK, message = "Update Cart Failed", });
            }
        }
        [HttpDelete("{Id}")]
        public virtual ActionResult Delete(int Id)
        {

            var delete = repository.Delete(Id);
            if (delete >= 1)
            {
                return StatusCode(200, new { status = HttpStatusCode.OK, message = "Data Deleted", Data = delete });
            }
            else if (delete == 0)
            {
                return StatusCode(404, new { status = HttpStatusCode.NotFound, message = "Data Id: " + Id + " Not Found", Data = delete });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Error", Data = delete });
            }
        }
        [HttpGet("{Id}")]
        public virtual ActionResult Get(int Id)
        {
            var get = repository.Get(Id);
            if (get == null)
            {
                return NotFound(new { message = "Data Not Found", get });
            }
            else
                return Ok(new { status = HttpStatusCode.OK, message = "Data Found", get });
        }
    }
}

   