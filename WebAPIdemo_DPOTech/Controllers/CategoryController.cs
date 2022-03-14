using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIdemo_DPOTech.DB.IService;
using WebAPIdemo_DPOTech.DB.Models;

namespace WebAPIdemo_DPOTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService<Category> _categoryService;

        public CategoryController(ICategoryService<Category> categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetCategories")]
        public List<Category> GetCategories()
        {
            return _categoryService.GetData();
        }

        [HttpPost("Add")]
        public IActionResult AddNewCategory(Category newCategory)
        {
            try
            {
                _categoryService.Add(newCategory);
                return Ok(" thêm thành công!");
            }
            catch (Exception e)
            {

                return BadRequest("Erorr"+e);
            }
        }

        [HttpPut("Edit")]
        public IActionResult EditCategory(Category categoryEdited)
        {
            try
            {
                _categoryService.Edit(categoryEdited);
                return Ok(" Sửa Thành Công!");
            }
            catch (Exception e)
            {
                return BadRequest("Erorr" + e);
            }
        }
    }

}
