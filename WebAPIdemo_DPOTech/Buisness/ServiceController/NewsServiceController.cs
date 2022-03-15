using WebAPIdemo_DPOTech.Buisness.ModelsForController;
using WebAPIdemo_DPOTech.DB.IService;
using WebAPIdemo_DPOTech.DB.Models;
using Category = WebAPIdemo_DPOTech.DB.Models.Category;

namespace WebAPIdemo_DPOTech.Buisness.ServiceForController;

public class NewsServiceController
{
    private readonly ICategoryService _categoryService;
    private readonly INewsService _newsService;
    private List<Category> _lstCategories;
    private List<News> _lstNews;
    private List<NewsView> _lstNewsForViews;

    public NewsServiceController(ICategoryService categoryService, INewsService newsService)
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

    public List<NewsView> GetNewsForAll()
    {
        GetListCategories();
        GetListNews();
        _lstNewsForViews = new List<NewsView>();
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
            NewsView news = new NewsView(x.NewsID, x.CategoryOfNews, x.NewName, x.NewContent, x.NewImage);
            _lstNewsForViews.Add(news);
        }
        return _lstNewsForViews;
    }

    public string AddNews(NewsView newsForView)
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

    public string EditNews(NewsView newsForView)
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
            Category newCategoryForView = new Category();
            newCategoryForView.CategoryId = Guid.NewGuid();
            newCategoryForView.CategoryName = newsForView.NewsName;
            newInput.CategoryId = newCategoryForView.CategoryId;
            _categoryService.Add(newCategoryForView);
        }

        return _newsService.Add(newInput) + " " + _categoryService.Save();
    }

    public string DeleteNews(NewsView newsForView)
    {
        GetListNews();
        News news = new News();
        news = _lstNews.Find(c => c.NewsName == newsForView.NewsName);
        return _newsService.Delete(news) + " " + _newsService.Save();
    }


}