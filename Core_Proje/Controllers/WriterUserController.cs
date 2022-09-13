using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Proje.Controllers
{
    public class WriterUserController : Controller
    {
        private readonly IWriterService _writerService;

        public WriterUserController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListUser()
        {

            var values = JsonConvert.SerializeObject(_writerService.TGetList());
            return Json(values);
        }
        public IActionResult AddUser(WriterUser p)
        {
            _writerService.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
    }
}
