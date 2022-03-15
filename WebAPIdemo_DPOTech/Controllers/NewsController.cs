using System.Net;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebAPIdemo_DPOTech.Buisness.ModelsForController;
using WebAPIdemo_DPOTech.Buisness.ServiceForController;

namespace WebAPIdemo_DPOTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsServiceController _serviceForController;

        public NewsController(NewsServiceController serviceForController)
        {
            _serviceForController = serviceForController;
        }

        [HttpGet("Get")]
        public List<NewsView> GetNews()
        {

            try
            {
                return _serviceForController.GetNewsForAll();
            }
            catch (Exception e)
            {

                return null;
            }
        }

        [HttpGet("GetOne/{name}")]
        public NewsView GetOne(string name)
        {
            try
            {

                NewsView newsForView = new NewsView();
                newsForView = _serviceForController.GetNewsForAll()[_serviceForController.GetNewsForAll().FindIndex(c => c.NewsName == name)];
                return newsForView;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(NewsView newsForView)
        {

            try
            {
                _serviceForController.AddNews(newsForView);
                return Ok("Thêm Thành Công!");
            }
            catch (Exception e)
            {

                return BadRequest(" Erorr" + e);
            }
        }

        [HttpPut("Edit/{name}")]
        public IActionResult Edit(NewsView newsForView)
        {

            try
            {
                _serviceForController.EditNews(newsForView);
                return Ok("Sửa Thành Công!");
            }
            catch (Exception e)
            {

                return BadRequest(" Erorr" + e);
            }
        }
        [HttpDelete("Delete/{name}")]
        public IActionResult Delete(NewsView newsForView)
        {
            try
            {
                _serviceForController.DeleteNews(newsForView);
                return Ok("Xóa Thành Công!");
            }
            catch (Exception e)
            {

                return BadRequest(" Erorr" + e);
            }
        }

    }
}
