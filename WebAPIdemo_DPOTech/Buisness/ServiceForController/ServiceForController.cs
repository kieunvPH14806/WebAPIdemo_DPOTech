using WebAPIdemo_DPOTech.Buisness.ModelsForController;
using WebAPIdemo_DPOTech.DB.IService;
using WebAPIdemo_DPOTech.DB.Models;

namespace WebAPIdemo_DPOTech.Buisness.ServiceForController;

public class ServiceForController
{
    private readonly ICategoryService _categoryService;
    private readonly INewsService _newsService;
    private List<Category> _lstCategories;
    private List<News> _lstNews;
    private List<NewsForView> _lstNewsForViews;

    public ServiceForController(ICategoryService categoryService, INewsService newsService)
    {
        _categoryService = categoryService;
        _newsService = newsService;
        GetListCategories();
        GetListNews();
    }

    public List<Category> GetListCategories()
    {
        _lstCategories = new List<Category>();
        _lstCategories = _categoryService.GetData().Where(c => c.CategoryStatus == true).ToList();
        return _lstCategories;
    }

    public List<News> GetListNews()
    {
        _lstNews = new List<News>();
        _lstNews = _newsService.GetData().Where(c => c.NewsStatus == true).ToList();
        return _lstNews;
    }

    public List<NewsForView> GetNewsForAll()
    {
        GetListCategories();
        GetListNews();
        _lstNewsForViews = new List<NewsForView>();
        var listNewsTemp = from news in _lstNews
                           join
                               category in _lstCategories on news.CategoryId equals category.CategoryId
                           select new
                           {
                               NewsID = news.NewsId,
                               NewName = news.NewsName,
                               CategoryOfNews = category.CategoryName,
                               NewContent = news.NewsContent,
                               NewImage = news.NewsImage
                           };
        foreach (var x in listNewsTemp)
        {
            NewsForView news = new NewsForView(x.NewsID, x.CategoryOfNews, x.NewName, x.NewContent, x.NewImage);
            _lstNewsForViews.Add(news);
        }
        return _lstNewsForViews;
    }

    public string AddNews(NewsForView newsForView)
    {
        GetListCategories();
        GetListNews();
        News newInput = new News();
        newInput.NewsId = newsForView.NewsId;
        newInput.NewsName = newsForView.NewsName;
        newInput.NewsContent = newsForView.NewsContent;
        newInput.NewsImage = newsForView.NewsImage;

        if (_lstCategories.Any(c => c.CategoryName == newsForView.Category))
        {
            newInput.CategoryId = _lstCategories[_lstCategories.FindIndex(c => c.CategoryName == newsForView.Category)]
                .CategoryId;

        }
        else
        {
            Category newCategory = new Category();
            newCategory.CategoryName = newsForView.NewsName;
            _categoryService.Add(newCategory);
        }

        return _newsService.Add(newInput) + "  " + _categoryService.Save();

    }

    public string EditNews(NewsForView newsForView)
    {
        GetListCategories();
        GetListNews();
        News newInput = new News();
        newInput.NewsId = Guid.NewGuid();
        newInput.NewsName = newsForView.NewsName;
        newInput.NewsContent = newsForView.NewsContent;
        newInput.NewsImage = newsForView.NewsImage;

        if (_lstCategories.Any(c => c.CategoryName == newsForView.Category))
        {
            newInput.CategoryId = _lstCategories[_lstCategories.FindIndex(c => c.CategoryName == newsForView.Category)]
                .CategoryId;

        }
        else
        {
            Category newCategory = new Category();
            newCategory.CategoryId = Guid.NewGuid();
            newCategory.CategoryName = newsForView.NewsName;
            newInput.CategoryId = newCategory.CategoryId;
            _categoryService.Add(newCategory);
        }

        return _newsService.Add(newInput) + " " + _categoryService.Save();
    }

    public string DeleteNews(NewsForView newsForView)
    {
        GetListNews();
        News news = new News();
        news = _lstNews.Find(c => c.NewsName == newsForView.NewsName);
        return _newsService.Delete(news) + " " + _newsService.Save();
    }


}