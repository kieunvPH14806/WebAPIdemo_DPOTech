namespace WebAPIdemo_DPOTech.DB.IService;

public interface ICategoryService<T>
{
    public List<T> GetData();
    public string Add(T @object);
    public string Edit(T @object);
    public string Delete(T @object);
    public string Save();
}