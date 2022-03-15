using WebAPIdemo_DPOTech.DB.Models;

namespace WebAPIdemo_DPOTech.DB.IService;

public interface ICategoryService
{
    public List<Category> GetData();
    public string Add(Category category);
    public string Edit(Category category);
    public string Delete(Category category);
    public string Save();
}