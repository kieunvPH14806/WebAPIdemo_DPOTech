using WebAPIdemo_DPOTech.Buisness.ModelsForController;
using WebAPIdemo_DPOTech.DB.DbWebContext;
using WebAPIdemo_DPOTech.DB.IService;
using WebAPIdemo_DPOTech.DB.Models;


namespace WebAPIdemo_DPOTech.Buisness.ServiceForController;

public class CategoryServiceController
{
    private readonly ICategoryService _categoryService;
    private List<CategoryView> _lstCategoryForViews;

    public CategoryServiceController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
        
    }

    public List<CategoryView> GetLstCategoryForViews()
    {
        foreach (var x in _categoryService.GetData().Where(c => c.CategoryStatus == true))
        {
            CategoryView categorytemp = new CategoryView(x.CategoryId, x.CategoryName, x.CategoryDescription);
            _lstCategoryForViews.Add(categorytemp);
        }
        return _lstCategoryForViews;
    }

    public string AddCategory(CategoryView categoryNew)
    {
        Category categoryInput = new Category();
        categoryInput.CategoryId = Guid.NewGuid();
        categoryInput.CategoryName = categoryNew.CategoryName;
        categoryInput.CategoryDescription = categoryNew.CategoryDescription;
        return _categoryService.Add(categoryInput) + _categoryService.Save();
    }
    public string EditCategory(CategoryView categoryEdited)

    {
        Category categoryInput = new Category();
        categoryInput.CategoryId = categoryEdited.CategoryId;
        categoryInput.CategoryName = categoryEdited.CategoryName;
        categoryInput.CategoryDescription = categoryEdited.CategoryDescription;
        return _categoryService.Edit(categoryInput) + _categoryService.Save();
    }

    public string DeleteCategory(CategoryView categoryDelete)
    {
        Category categoryInput = new Category();
        categoryInput = _categoryService.GetData().Find(c => c.CategoryId == categoryDelete.CategoryId);
        return _categoryService.Delete(categoryInput);
    }

}