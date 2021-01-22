using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WSFlutterEniProject.Interfaces;
using WSFlutterEniProject.Models.Requests;
using WSFlutterEniProject.Models.Response;

namespace WSFlutterEniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {

        private IProductInterface _productInterface;

        public ProductController( IProductInterface productInterface)
        {
            this._productInterface = productInterface;
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Response response = new Response();
            try
            {
                _productInterface.Delete(id);
                response.Successful = true;

            }
            catch (Exception err)
            {
                response.Message = err.Message;
            }
            return Ok(response);
        }


        [HttpPost]
        public IActionResult Add(ProductRequest request)
        {
            Response response = new Response();
            try
            {
                _productInterface.Add(request);
                response.Successful = true;

            }
            catch (Exception err)
            {
                response.Message = err.Message;   
            }
            return Ok(response);


        }


        [HttpPut]
        public IActionResult Update(ProductRequest request)
        {
            Response response = new Response();
            try
            {
                _productInterface.Update(request);
                response.Successful = true;

            }
            catch (Exception err)
            {
                response.Message = err.Message;
            }
            return Ok(response);


        }


        [HttpGet]
        [Route("category/{id:int}")]
       public IActionResult GetByCategory(int id)
        {
            Response response = new Response();

            try
            {
                response.Data = _productInterface.GetByCategory(id);
                response.Successful = true;

            }
            catch (Exception err)
            {
                response.Message = err.Message;
            }

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Response response = new Response();
            try
            {
                response.Data = _productInterface.GetById(id);
                response.Successful = true;

            }
            catch (Exception err )
            {
                response.Message = err.Message;
            }
            return Ok(response);
        }

    }
}
