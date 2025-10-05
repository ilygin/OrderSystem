using Microsoft.AspNetCore.Mvc;
using OrderSystem.Domain.DTO;
using OrderSystem.Domain.Interfaces;
using OrderSystem.Domain.Models;


namespace OrderSystem.Infrastructure.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService service)
        {
            _orderService = service;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public BaseResponse<IEnumerable<Order>> Get()
        {
            BaseResponse<IEnumerable<Order>> resp = new BaseResponse<IEnumerable<Order>>();
            try
            {
                resp.Data = _orderService.GetAllOrders();
                resp.Code = 200;
                resp.Message = "Success";
            }
            catch (Exception ex)
            {
                resp.Code = 500;
                resp.Message = ex.Message;
            }
            return resp;
        }

        // GET api/<OrdersController>/guid
        [HttpGet("{id}")]
        public BaseResponse<Order> Get(Guid id)
        {
            BaseResponse<Order> resp = new BaseResponse<Order>();

            if (id == Guid.Empty)
            {
                resp.Code = 500;
                resp.Message = "Id is empty";
                return resp;
            }

            try
            {
                resp.Data = _orderService.GetOrder(id);
                resp.Code = 200;
                resp.Message = "Success";
            }
            catch (Exception ex)
            {
                resp.Code = 500;
                resp.Message = ex.Message;
            }
            return resp;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public BaseResponse<Order> Post([FromBody] OrderRequestDto? data)
        {
            BaseResponse<Order> resp = new BaseResponse<Order>();
            if (data == null)
            {
                resp.Code = 500;
                resp.Message = "data is empty";
                return resp;
            }

            try
            {
                resp.Data = _orderService.CreateOrder(data);
                resp.Code = 200;
                resp.Message = "Success";
            }
            catch (Exception ex)
            {
                resp.Code = 500;
                resp.Message = ex.Message;
            }
            return resp;
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public BaseResponse<Order> Put(Guid id, [FromBody] OrderRequestDto data)
        {
            BaseResponse<Order> resp = new BaseResponse<Order>();
            if (data == null)
            {
                resp.Code = 500;
                resp.Message = "data is empty";
                return resp;
            }

            if (id == Guid.Empty)
            {
                resp.Code = 500;
                resp.Message = "Id is empty";
                return resp;
            }

            try
            {
                resp.Data = _orderService.UpdateOrder(id, data);
                resp.Code = 200;
                resp.Message = "Success";
            }
            catch (Exception ex)
            {
                resp.Code = 500;
                resp.Message = ex.Message;
            }
            return resp;
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public BaseResponse<bool> Delete(Guid id)
        {
            BaseResponse<bool> resp = new BaseResponse<bool>();

            if (id == Guid.Empty)
            {
                resp.Code = 500;
                resp.Message = "Id is empty";
                return resp;
            }
            try
            {
                resp.Data = _orderService.DeleteOrder(new OrderRequestDto() { Id = id });
                resp.Code = 200;
                resp.Message = "Success";
            }
            catch (Exception ex)
            {
                resp.Code = 500;
                resp.Message = ex.Message;
            }
            return resp;
        }
    }
}