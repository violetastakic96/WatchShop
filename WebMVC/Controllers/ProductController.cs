using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Commands.Brand;
using Business.Commands.Gender;
using Business.Commands.Mechanism;
using Business.Commands.Product;
using Business.DataTransferObjects;
using Business.Exceptions;
using Business.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetProductsCommand _getProducts;
        private readonly IGetProductCommand _getProduct;
        private readonly IAddProductCommand _addProduct;
        private readonly IEditProductCommand _editProduct;
        private readonly IDeleteProductCommand _deleteProduct;
        private readonly IGetGendersCommand _getGenders;
        private readonly IGetBrandsCommand _getBrands;
        private readonly IGetMechanismsCommand _getMechanisms;
        private readonly IGetProductForEditCommand _getProductForEdit;

        public ProductController(IGetProductsCommand getProducts, IGetProductCommand getProduct, IAddProductCommand addProduct, IEditProductCommand editProduct, IDeleteProductCommand deleteProduct, IGetGendersCommand getGenders, IGetBrandsCommand getBrands, IGetMechanismsCommand getMechanisms, IGetProductForEditCommand getProductForEdit)
        {
            _getProducts = getProducts;
            _getProduct = getProduct;
            _addProduct = addProduct;
            _editProduct = editProduct;
            _deleteProduct = deleteProduct;
            _getGenders = getGenders;
            _getBrands = getBrands;
            _getMechanisms = getMechanisms;
            _getProductForEdit = getProductForEdit;
        }


        // GET: Product
        public ActionResult Index(ProductQuery query)
        {
            return View(_getProducts.Execute(query));
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(_getProduct.Execute(id));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.Genders = _getGenders.Execute(new GenderQuery()).Data;
            ViewBag.Brands = _getBrands.Execute(new BrandQuery()).Data;
            ViewBag.Mechanisms = _getMechanisms.Execute(new MechanismQuery()).Data;
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Inaccurate create object";
                RedirectToAction(nameof(Create));
            }
            try
            {
                _addProduct.Execute(dto);
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Genders = _getGenders.Execute(new GenderQuery()).Data;
            ViewBag.Brands = _getBrands.Execute(new BrandQuery()).Data;
            ViewBag.Mechanisms = _getMechanisms.Execute(new MechanismQuery()).Data;
            return View(_getProductForEdit.Execute(id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            dto.Id = id;
            try
            {
                _editProduct.Execute(dto);
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteProduct.Execute(id);
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