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
        private readonly CategoryServiceController _categoryController;


        public CategoryController(CategoryServiceController categoryController)
        {
            _categoryController = categoryController;
        }

        [HttpGet("Get")]
        public List<Buisness.ModelsForController.CategoryView> GetCategories()
        {
            return _categoryController.GetLstCategoryForViews();
        }

        [HttpPost("Add")]
        public IActionResult AddNewCategory(CategoryView newCategoryForView)
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
        public IActionResult Edit(CategoryView categoryForViewEdited)
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
        public IActionResult Delete(CategoryView categoryForViewToDelete)
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
