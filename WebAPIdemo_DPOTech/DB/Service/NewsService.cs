using WebAPIdemo_DPOTech.DB.IService;
using WebAPIdemo_DPOTech.DB.DbWebContext;


namespace WebAPIdemo_DPOTech.DB.Service;

public class Service<T>:ICategoryService<T> where T : class
{
    private readonly DbWebContext.DbWebContext _dbContext;
    public Service(DbWebContext.DbWebContext dbContext )
    {
        _dbContext=dbContext;
    }
    public List<T> GetData()
    {
        try
        {
            return _dbContext.Set<T>().ToList();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public string Add(T @object)
    {
        try
        {
            _dbContext.Set<T>().Add(@object);
            return "Sucessful";
        }
        catch (Exception e)
        {
            return "Erorr" + e;
        }
    }

    public string Edit(T @object)
    {
        try
        {
            _dbContext.Set<T>().Update(@object);
            return "Sucessful";
        }
        catch (Exception e)
        {

            return "Erorr" + e;
        }
    }

    public string Delete(T @object)
    {
        try
        {
            _dbContext.Set<T>().Remove(@object);
            return "Sucessful";
        }
        catch (Exception e)
        {
            return "Erorr"+ e;
        }
    }

    public string Save()
    {
        try
        {
            _dbContext.SaveChanges();
            return "Sucessful";
        }
        catch (Exception e)
        {
            return "Erorr" + e;
        }
    }
}