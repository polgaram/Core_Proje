using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class ToDoListPanel:ViewComponent
    {
        private readonly IToDoListService _toDoListService;

        public ToDoListPanel(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _toDoListService.TGetList();
            return View(values);
        }
    }
}
