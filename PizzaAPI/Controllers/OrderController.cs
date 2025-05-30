using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaAPI.Data;
using PizzaAPI.Data.DTOs;
using PizzaAPI.Data.Entities;
using PizzaAPI.Data.Interfaces;
using System.Security.Claims;

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /*
               [HttpPost("PostFoodType")]
        public async Task<IActionResult> PostFoodType(FoodTypeEntity foodTypeEntity)
        {
            try
            {
                await _orderService.PostFoodType(foodTypeEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostFood")]
        public async Task<IActionResult> PostFood(FoodCreateDTO dto)
        {
            try
            {
                await _orderService.PostFood(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */
        

        [HttpGet("GetFoodTypes")]
        public async Task<IActionResult> GetFoodTypes()
        {
            try
            {
                List<FoodTypeEntity> foodTypes = await _orderService.GetFoodTypes();
                return Ok(foodTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetFoods")]
        public async Task<IActionResult> GetFoods()
        {
            try
            {
                List<FoodEntity> list = await _orderService.GetFoods();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostOrder")]
        public async Task<IActionResult> PostOrder(OrderDTO dto)
        {
            try
            {
                await _orderService.PostOrder(dto, int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                int AccountID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                return Ok(await _orderService.GetOrders(AccountID));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
