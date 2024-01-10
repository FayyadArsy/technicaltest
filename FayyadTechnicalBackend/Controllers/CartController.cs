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
        public virtual ActionResult Insert(ViewModel.CartVm insert)
        {
           try{
                repository.Insert(insert);
                return Ok(new { status = HttpStatusCode.OK, message = "Data Inserted"});
           }
           catch (Exception e){
                return BadRequest(new { status = HttpStatusCode.OK, message = "Insert Failed", });
           }
        }
       
    }
}

   