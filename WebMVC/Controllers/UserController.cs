using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Commands.Role;
using Business.Commands.User;
using Business.DataTransferObjects;
using Business.Exceptions;
using Business.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IGetUserCommand _getUser;
        private readonly IGetUsersCommand _getUsers;
        private readonly IAddUserCommand _addUser;
        private readonly IEditUserCommand _editUser;
        private readonly IDeleteUserCommand _deleteUser;
        private readonly IGetRolesCommand _getRoles;
        private readonly IGetUserForEditCommand _getUserForEdit;

        public UserController(IGetUserCommand getUser, IGetUsersCommand getUsers, IAddUserCommand addUser, IEditUserCommand editUser, IDeleteUserCommand deleteUser, IGetRolesCommand getRoles, IGetUserForEditCommand getUserForEdit)
        {
            _getUser = getUser;
            _getUsers = getUsers;
            _addUser = addUser;
            _editUser = editUser;
            _deleteUser = deleteUser;
            _getRoles = getRoles;
            _getUserForEdit = getUserForEdit;
        }


        // GET: User
        public ActionResult Index()
        {
            return View(_getUsers.Execute(new UserQuery()));
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View(_getUser.Execute(id));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.Roles = _getRoles.Execute(new RoleQuery()).Data;
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Inaccurate create object";
                RedirectToAction(nameof(Create));
            }
            try
            {
                _addUser.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException e)
            {
                TempData["error"] = e.Message;
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
            }
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Roles = _getRoles.Execute(new RoleQuery()).Data;
            return View(_getUserForEdit.Execute(id));
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            dto.Id = id;
            try
            {
                _editUser.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException e)
            {
                TempData["error"] = e.Message;
                return View(dto);
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
                return View(dto);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteUser.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        
    }
}