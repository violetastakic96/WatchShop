using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Commands.Brand;
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
    public class BrandController : ControllerBase
    {

        private readonly IGetBrandCommand _getBrand;
        private readonly IGetBrandsCommand _getBrands;
        private readonly IAddBrandCommand _addBrand;
        private readonly IDeleteBrandCommand _deleteBrand;
        private readonly IEditBrandCommand _editBrand;
        private readonly LoggedUser _user;

        public BrandController(IGetBrandCommand getBrand, IGetBrandsCommand getBrands, IAddBrandCommand addBrand, IDeleteBrandCommand deleteBrand, IEditBrandCommand editBrand, LoggedUser user)
        {
            _getBrand = getBrand;
            _getBrands = getBrands;
            _addBrand = addBrand;
            _deleteBrand = deleteBrand;
            _editBrand = editBrand;
            _user = user;
        }
        /// <summary>
        /// Shows all brands
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Basket
        ///     {
        ///        "Name": "Fossil",
        ///        "PerPage": 6,
        ///        "PageNumber": 2
        ///     }
        ///
        /// </remarks>
        // GET: api/Brand
        [HttpGet]
        public ActionResult<PagedResponse<BrandDto>> Get([FromQuery]BrandQuery query)
        {
            return Ok(_getBrands.Execute(query));
        }
        /// <summary>
        /// Shows specific brand information
        /// </summary>
        // GET: api/Brand/5
        [HttpGet("{id}")]
        public ActionResult<BrandDto> Get(int id)
        {
            try
            {
                return Ok(_getBrand.Execute(id));
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
        /// Adds brand 
        /// </summary>
        // POST: api/Brand
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] BrandDto dto)
        {
            try
            {
                _addBrand.Execute(dto);
                return StatusCode(201);
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
        /// Edits brand
        /// </summary>
        // PUT: api/Brand/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BrandDto dto)
        {
            try
            {
                dto.Id = id;
                _editBrand.Execute(dto);
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
        /// Deletes brand
        /// </summary>
        // DELETE: api/ApiWithActions/5
        [LoggedIn("Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteBrand.Execute(id);
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
