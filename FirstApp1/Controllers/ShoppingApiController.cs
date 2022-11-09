using FirstApp1.EFCore;
using FirstApp1.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstApp1.Controllers
{
    
    [ApiController]
    public class ShoppingApiController : ControllerBase
    {
        private readonly DbHelper _db;
        public ShoppingApiController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }
        // GET: api/<ShoppingApiController>
        [HttpGet]
        [Route("api/[controller]/GetProducts")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<ProductModel> data = _db.GetProducts();
                
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {

                
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<ShoppingApiController>/5
        [HttpGet]
        [Route("api/[controller]/GetProductById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                ProductModel data = _db.GetProductById(id);

                if (data!= null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {

             
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        } 

        // POST api/<ShoppingApiController>
        [HttpPost]
        [Route("api/[controller]/SaveOrder")]
        public IActionResult Post1([FromBody] OrderModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/AddOrder")]
        public IActionResult Post([FromBody] OrderModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.AddOrder(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<ShoppingApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateOrder")]
        public IActionResult Put(int id, [FromBody] OrderModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<ShoppingApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteOrder/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteOrder(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Success"));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
