using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIdemo_DPOTech.Buisness.ModelsForController;
using WebAPIdemo_DPOTech.Buisness.ServiceForController;
using WebAPIdemo_DPOTech.DB.IService;
using WebAPIdemo_DPOTech.DB.Models;
using Category = WebAPIdemo_DPOTech.DB.Models.Category;

namespace WebAPIdemo_DPOTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryServiceForController _categoryController;


        public CategoryController(CategoryServiceForController categoryController)
        {
            _categoryController = categoryController;
        }

        [HttpGet("Get")]
        public List<Buisness.ModelsForController.CategoryForView> GetCategories()
        {
            return _categoryController.GetLstCategoryForViews();
        }

        [HttpPost("Add")]
        public IActionResult AddNewCategory(CategoryForView newCategoryForView)
        {
            try
            {
                return Ok(_categoryController.AddCategory(newCategoryForView));
            }
            catch (Exception e)
            {

                return BadRequest("Erorr"+e);
            }
        }

        [HttpPut("Edit/{name}")]
        public IActionResult Edit(CategoryForView categoryForViewEdited)
        {
            try
            {
                return Ok(_categoryController.EditCategory(categoryForViewEdited));
            }
            catch (Exception e)
            {
                return BadRequest("Erorr" + e);
            }
        }

        [HttpDelete("Delete/{name}")]
        public IActionResult Delete(CategoryForView categoryForViewToDelete)
        {
            try
            {
                return Ok(_categoryController.DeleteCategory(categoryForViewToDelete));
            }
            catch (Exception e)
            {
                return BadRequest("Erorr"+ e);
            }
        }
        
    }

}
