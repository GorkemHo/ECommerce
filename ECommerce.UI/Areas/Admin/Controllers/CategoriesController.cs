using ECommerce.Application.Models.DTOs.CategortyDto;
using ECommerce.Application.Services.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categoryList = await _categoryService.GetCategories();
            return View(categoryList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // var model = await _categoryService.Create();
            //model.Ca = await _categoryService.GetCategories();

            // return View(model);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto model)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateCategoryDto model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id; 
                await _categoryService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

         //[HttpPost, ActionName("Delete")]
      [HttpPost]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }//GÖRSEL EKLE
            return View(category);
        }
    }


}

