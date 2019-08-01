using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Commands.Product;
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
    public class ProductController : ControllerBase
    {
        private readonly IGetProductCommand _getProduct;
        private readonly IGetProductsCommand _getProducts;
        private readonly IAddProductCommand _addProduct;
        private readonly IDeleteProductCommand _deleteProduct;
        private readonly IEditProductCommand _editProduct;
        private readonly LoggedUser _user;

        public ProductController(IGetProductCommand getProduct, IGetProductsCommand getProducts, IAddProductCommand addProduct, IDeleteProductCommand deleteProduct, IEditProductCommand editProduct, LoggedUser user)
        {
            _getProduct = getProduct;
            _getProducts = getProducts;
            _addProduct = addProduct;
            _deleteProduct = deleteProduct;
            _editProduct = editProduct;
            _user = user;
        }

        /// <summary>
        /// Shows all products
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///        "Name": "Product1",
        ///        "MinPrice": 25,
        ///        "MaxPrice": 50,
        ///        "Waterproof": true,
        ///        "IsAvailable": true,
        ///        "MechanismId": 1,
        ///        "GenderId": 2,
        ///        "BrandId": 2,
        ///        "PerPage": 6,
        ///        "PageNumber": 2
        ///     }
        ///
        /// </remarks>
        // GET: api/Product
        [HttpGet]
        public ActionResult<PagedResponse<ShowProductDto>> Get([FromQuery] ProductQuery query)
        {
            return Ok(_getProducts.Execute(query));
        }

        /// <summary>
        /// Shows specific product information
        /// </summary>
        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<ShowProductDto> Get(int id)
        {
            try
            {
                return Ok(_getProduct.Execute(id));
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
        /// Adds product 
        /// </summary>
        // POST: api/Product
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] ProductDto query)
        {
            try
            {
                _addProduct.Execute(query);
                return StatusCode(204);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(422, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Edits product
        /// </summary>
        // PUT: api/Product/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDto dto)
        {
            try
            {
                dto.Id = id;
                _editProduct.Execute(dto);
                return StatusCode(204);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(422, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        /// <summary>
        /// Deletes product
        /// </summary>
        // DELETE: api/ApiWithActions/5
        [LoggedIn("Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteProduct.Execute(id);
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
