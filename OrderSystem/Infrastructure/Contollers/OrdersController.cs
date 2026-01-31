using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Domain.Common;
using OrderSystem.Domain.DTO;
using OrderSystem.Domain.Interfaces;
using OrderSystem.Domain.Models;

namespace OrderSystem.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IValidator<OrderRequestDto> _validator;
        public OrdersController(IOrderService service, IValidator<OrderRequestDto> validator)
        {
            _orderService = service;
            _validator = validator;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public BaseResponse<IEnumerable<Order>> Get()
        {
            BaseResponse<IEnumerable<Order>> resp = new BaseResponse<IEnumerable<Order>>();
            try
            {
                resp.Data = _orderService.GetAllOrders().Body;
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
                resp.Code = 400;
                resp.Message = "Id is empty";
                return resp;
            }

            try
            {
                resp.Data = _orderService.GetOrder(id).Body;
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
                resp.Code = 400;
                resp.Message = "Request body is missing or invalid.";
                return resp;
            }

            ValidationResult validation = _validator.Validate(data);
            if (validation.IsValid == false)
            {
                resp.Message = string.Join("; ", validation.Errors.Select(e => e.ErrorMessage));
                resp.Code = 400;
                return resp;
            }

            try
            {
                Result<Order> result = _orderService.CreateOrder(data);
                if (result == null || !result.IsSuccess)
                {
                    resp.Code = 400;
                    resp.Message = string.IsNullOrWhiteSpace(result?.Message)
                        ? "Domain validation failed while creating the order."
                        : result.Message;
                    return resp;
                }
                resp.Data = result.Body;
                resp.Code = 200;
                resp.Message = string.IsNullOrWhiteSpace(result.Message) ? "Success" : result.Message;
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
                resp.Code = 400;
                resp.Message = "Request body is missing or invalid.";
                return resp;
            }

            ValidationResult validation = _validator.Validate(data);
            if (validation.IsValid == false)
            {
                resp.Message = string.Join("; ", validation.Errors.Select(e => e.ErrorMessage));
                resp.Code = 400;
                return resp;
            }

            if (id == Guid.Empty)
            {
                resp.Code = 400;
                resp.Message = "Id is empty";
                return resp;
            }

            try
            {
                resp.Data = _orderService.UpdateOrder(id, data).Body;
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
                resp.Code = 400;
                resp.Message = "Id is empty";
                return resp;
            }
            try
            {
                var result = _orderService.DeleteOrder(id);
                if (result.IsSuccess)
                {
                    resp.Data = result.Body;
                    resp.Code = 200;
                    resp.Message = "Success";
                }
                else
                {
                    resp.Data = result.Body;
                    resp.Code = 404;
                    resp.Message = result.Message ?? "Not found";
                }
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