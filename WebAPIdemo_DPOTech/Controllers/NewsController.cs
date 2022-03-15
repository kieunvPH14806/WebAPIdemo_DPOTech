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
        private readonly ServiceForController _serviceForController;

        public NewsController(ServiceForController serviceForController)
        {
            _serviceForController = serviceForController;
        }

        [HttpGet("Get")]
        public List<NewsForView> GetNews()
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
        public NewsForView GetOne(string name)
        {
            try
            {

                NewsForView newsForView = new NewsForView();
                newsForView = _serviceForController.GetNewsForAll()[_serviceForController.GetNewsForAll().FindIndex(c => c.NewsName == name)];
                return newsForView;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(NewsForView newsForView)
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
        public IActionResult Edit(NewsForView newsForView)
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
        public IActionResult Delete(NewsForView newsForView)
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
