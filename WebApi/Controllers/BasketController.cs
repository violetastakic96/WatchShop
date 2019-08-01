using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Commands.Basket;
using Business.DataTransferObjects;
using Business.Exceptions;
using Business.Helpers;
using Business.Queries;
using Business.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IAddToBasketCommand _addToBasket;
        private readonly IRemoveFromBasketCommand _removeFromBasket;
        private readonly IBuyCommand _buy;
        private readonly IGetUserBasketCommand _userBasket;
        private readonly IGetAllBasketsCommand _allBasket;
        private readonly LoggedUser _user;

        public BasketController(IAddToBasketCommand addToBasket, IRemoveFromBasketCommand removeFromBasket, IBuyCommand buy, IGetUserBasketCommand userBasket, IGetAllBasketsCommand allBasket, LoggedUser user)
        {
            _addToBasket = addToBasket;
            _removeFromBasket = removeFromBasket;
            _buy = buy;
            _userBasket = userBasket;
            _allBasket = allBasket;
            _user = user;
        }
        /// <summary>
        /// Shows all products in users basket
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Basket
        ///     {
        ///        "UserId": 1,
        ///        "PerPage": 6,
        ///        "PageNumber": 2
        ///     }
        ///
        /// </remarks>
        // GET: api/Basket
        [LoggedIn("Administrator")]
        [HttpGet]
        public ActionResult<PagedResponse<ShowAllBaskets>> Get([FromQuery]BasketQuery query)
        {
            return Ok(_allBasket.Execute(query));
        }
        /// <summary>
        /// Shows products that's in specific user basket
        /// </summary>
        // GET: api/Basket/5
        [LoggedIn("User")]
        [HttpGet("{id}")]
        public ActionResult<ShowBasketDto> Get(int id)
        {
            try
            {
                return Ok(_userBasket.Execute(id));
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// Adds products to basket
        /// </summary>

        [HttpPost]
        [LoggedIn("User")]
        public IActionResult Post([FromBody] BasketDto dto)
        {
            try
            {
                _addToBasket.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }
        /// <summary>
        /// Remove some product from basket
        /// </summary>
        [LoggedIn("User")]
        [HttpPost]
        [Route("removefrombasket")]
        public IActionResult RemoveFromBasket([FromBody] RemoveBasketDto dto)
        {
            try
            {
                _removeFromBasket.Execute(dto);
                return StatusCode(204);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Buy products from basket
        /// </summary>

        [LoggedIn("User")]
        [HttpGet]
        [Route("buy")]
        public IActionResult Buy(int id)
        {
            try
            {
                _buy.Execute(id);
                return StatusCode(204);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
