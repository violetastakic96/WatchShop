using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Commands.ProductPhoto;
using Business.DataTransferObjects;
using Business.Exceptions;
using Business.Helpers;
using Business.Queries;
using Business.Responses;
using EfCommands.ProductPhoto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPhotoController : ControllerBase
    {
        private readonly IGetProductPhotoCommand _getPP;
        private readonly IGetProductPhotosCommand _getPPs;
        private readonly IAddProductPhotoCommand _addPP;
        private readonly IEditProductPhotoCommand _editPP;
        private readonly IDeleteProductPhotoCommand _deletePP;
        private readonly LoggedUser _user;

        public ProductPhotoController(IGetProductPhotoCommand getPP, IGetProductPhotosCommand getPPs, IAddProductPhotoCommand addPP, IEditProductPhotoCommand editPP, IDeleteProductPhotoCommand deletePP, LoggedUser user)
        {
            _getPP = getPP;
            _getPPs = getPPs;
            _addPP = addPP;
            _editPP = editPP;
            _deletePP = deletePP;
            _user = user;
        }

        /// <summary>
        /// Shows all product photos
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /ProductPhoto
        ///     {
        ///        "ProductId": 1,
        ///        "PerPage": 6,
        ///        "PageNumber": 2
        ///     }
        ///
        /// </remarks>
        // GET: api/ProductPhoto
        [HttpGet]
        public ActionResult<PagedResponse<ShowProductPhoto>> Get([FromQuery] ProductPhotoQuery query)
        {
            return Ok(_getPPs.Execute(query));
        }

        /// <summary>
        /// Shows specific product photo information
        /// </summary>
        // GET: api/ProductPhoto/5
        [HttpGet("{id}")]
        public ActionResult<ShowProductPhoto> Get(int id)
        {
            try
            {
                return Ok(_getPP.Execute(id));
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
        /// Adds product photo 
        /// </summary>
        // POST: api/ProductPhoto
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromForm] FileRequest request)
        {
            var ext = Path.GetExtension(request.File.FileName);

            if (!UploadFile.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed");
            }
            var newFileName = Guid.NewGuid().ToString() + "_" + request.File.FileName;

            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "productPhotos", newFileName);

                request.File.CopyTo(new FileStream(filePath, FileMode.Create));

                var dto = new ProductPhotoDto
                {
                    Alt = request.Alt,
                    Id = request.ProductId,
                    Path = Path.Combine("uploads", newFileName)

                };
                _addPP.Execute(dto);

                return StatusCode(201);
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
        /// Edits product photo
        /// </summary>
        // PUT: api/ProductPhoto/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductPhotoDto dto)
        {
            try
            {
                dto.Id = id;
                _editPP.Execute(dto);
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
        /// Deletes product photo
        /// </summary>
        // DELETE: api/ApiWithActions/5
        [LoggedIn("Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deletePP.Execute(id);
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
