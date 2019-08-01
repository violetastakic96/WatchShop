using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Commands.Gender;
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
    public class GenderController : ControllerBase
    {
        private readonly IGetGenderCommand _getGender;
        private readonly IGetGendersCommand _getGenders;
        private readonly IEditGenderCommand _editGender;
        private readonly IDeleteGenderCommand _deleteGender;
        private readonly IAddGenderCommand _addGender;
        private readonly LoggedUser _user;

        public GenderController(IGetGenderCommand getGender, IGetGendersCommand getGenders, IEditGenderCommand editGender, IDeleteGenderCommand deleteGender, IAddGenderCommand addGender, LoggedUser user)
        {
            _getGender = getGender;
            _getGenders = getGenders;
            _editGender = editGender;
            _deleteGender = deleteGender;
            _addGender = addGender;
            _user = user;
        }
        /// <summary>
        /// Shows all genders
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Gender
        ///     {
        ///        "Name": "Male",
        ///        "PerPage": 6,
        ///        "PageNumber": 2
        ///     }
        ///
        /// </remarks>
        // GET: api/Gender
        [HttpGet]
        public ActionResult<PagedResponse<GenderDto>> Get([FromQuery]GenderQuery query)
        {
            return Ok(_getGenders.Execute(query));
        }
        /// <summary>
        /// Shows specific gender information
        /// </summary>
        // GET: api/Gender/5
        [HttpGet("{id}")]
        public ActionResult<GenderDto> Get(int id)
        {
            try
            {
                return Ok(_getGender.Execute(id));
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
        /// Adds gender 
        /// </summary>
        // POST: api/Gender
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] GenderDto dto)
        {
            try
            {
                _addGender.Execute(dto);
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
        /// Edits gender
        /// </summary>
        // PUT: api/Gender/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GenderDto dto)
        {
            try
            {
                dto.Id = id;
                _editGender.Execute(dto);
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
        /// Deletes gender
        /// </summary>
        // DELETE: api/ApiWithActions/5
        [LoggedIn("Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteGender.Execute(id);
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
