using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Commands.User;
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
    public class UserController : ControllerBase
    {
        private readonly IGetUsersCommand _getUsers;
        private readonly IGetUserCommand _getUser;
        private readonly IAddUserCommand _addUser;
        private readonly IDeleteUserCommand _deleteUser;
        private readonly IEditUserCommand _editUser;
        private readonly LoggedUser _user;

        public UserController(IGetUsersCommand getUsers, IGetUserCommand getUser, IAddUserCommand addUser, IDeleteUserCommand deleteUser, IEditUserCommand editUser, LoggedUser user)
        {
            _getUsers = getUsers;
            _getUser = getUser;
            _addUser = addUser;
            _deleteUser = deleteUser;
            _editUser = editUser;
            _user = user;
        }

        /// <summary>
        /// Shows all users
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /User
        ///     {
        ///        "Email": "test@mail.com",
        ///        "Username": "test123",
        ///        "FirstName": "Pera",
        ///        "LastName": "Peric",
        ///        "PerPage": 6,
        ///        "PageNumber": 2
        ///     }
        ///
        /// </remarks>
        // GET: api/User
        [LoggedIn("Administrator")]
        [HttpGet]
        public ActionResult<PagedResponse<ShowUserDto>> Get([FromQuery] UserQuery query)
        {
            return Ok(_getUsers.Execute(query));
        }
        
        /// <summary>
        /// Shows specific user information
        /// </summary>
        // GET: api/User/5
        [LoggedIn("Administrator")]
        [HttpGet("{id}")]
        public ActionResult<ShowUserDto> Get(int id)
        {
            try
            {
                return Ok(_getUser.Execute(id));
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
        /// Adds user 
        /// </summary>
        // POST: api/User
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] UserDto query)
        {

            try
            {
                _addUser.Execute(query);
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
        /// Edits user
        /// </summary>
        // PUT: api/User/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto dto)
        {
            try
            {
                dto.Id = id;
                _editUser.Execute(dto);
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
        /// Deletes user
        /// </summary>
        // DELETE: api/ApiWithActions/5
        [LoggedIn("Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteUser.Execute(id);
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
