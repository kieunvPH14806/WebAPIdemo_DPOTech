using WebAPIdemo_DPOTech.DB.IService;
using WebAPIdemo_DPOTech.DB.DbWebContext;
using WebAPIdemo_DPOTech.DB.Models;


namespace WebAPIdemo_DPOTech.DB.Service;

public class NewsService:INewsService
{
    private readonly DbWebContext.DbWebContext _dbContext;
    public NewsService(DbWebContext.DbWebContext dbContext )
    {
        _dbContext=dbContext;
    }
    public List<News> GetData()
    {
        try
        {
            return _dbContext.Set<News>().ToList();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public string Add(News news)
    {
        
        news.NewsStatus = true;
        try
        {
            _dbContext.Set<News>().Add(news);
            return "Sucessful";
        }
        catch (Exception e)
        {
            return "Erorr" + e;
        }
    }

    public string Edit(News news)
    {
        try
        {
            _dbContext.Set<News>().Update(news);
            return "Sucessful";
        }
        catch (Exception e)
        {

            return "Erorr" + e;
        }
    }

    public string Delete(News news)
    {
        news.NewsStatus = false;
        try
        {
            _dbContext.Set<News>().Update(news);
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