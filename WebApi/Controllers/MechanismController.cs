using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Commands.Mechanism;
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
    public class MechanismController : ControllerBase
    {
        private readonly IGetMechanismCommand _getMechanism;
        private readonly IGetMechanismsCommand _getMechanisms;
        private readonly IAddMechanismCommand _addMechanism;
        private readonly IEditMechanismCommand _editMechanism;
        private readonly IDeleteMechanismCommand _deleteMechanism;
        private readonly LoggedUser _user;

        public MechanismController(IGetMechanismCommand getMechanism, IGetMechanismsCommand getMechanisms, IAddMechanismCommand addMechanism, IEditMechanismCommand editMechanism, IDeleteMechanismCommand deleteMechanism, LoggedUser user)
        {
            _getMechanism = getMechanism;
            _getMechanisms = getMechanisms;
            _addMechanism = addMechanism;
            _editMechanism = editMechanism;
            _deleteMechanism = deleteMechanism;
            _user = user;
        }

        /// <summary>
        /// Shows all mechanism
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Mechanism
        ///     {
        ///        "Name": "Automatic",
        ///        "PerPage": 6,
        ///        "PageNumber": 2
        ///     }
        ///
        /// </remarks>
        // GET: api/Mechanism
        [HttpGet]
        public ActionResult<PagedResponse<MechanismDto>> Get([FromQuery]MechanismQuery query)
        {
            return Ok(_getMechanisms.Execute(query));
        }

        /// <summary>
        /// Shows specific mechanism information
        /// </summary>
        // GET: api/Mechanism/5
        [HttpGet("{id}")]
        public ActionResult<MechanismDto> Get(int id)
        {
            try
            {
                return Ok(_getMechanism.Execute(id));
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
        /// Adds mechanism 
        /// </summary>
        // POST: api/Mechanism
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] MechanismDto dto)
        {
            try
            {
                _addMechanism.Execute(dto);
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
        /// Edits mechanism
        /// </summary>
        // PUT: api/Mechanism/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MechanismDto dto)
        {
            try
            {
                dto.Id = id;
                _editMechanism.Execute(dto);
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
        /// Deletes mechanism
        /// </summary>
        // DELETE: api/ApiWithActions/5
        [LoggedIn("Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteMechanism.Execute(id);
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
