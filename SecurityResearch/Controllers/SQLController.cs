using Microsoft.AspNetCore.Mvc;
using SecurityResearch.Models;

namespace SecurityResearch.Controllers
{
    public class SQLController : Controller
    {
        DAL _dal = new();
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string forename, string lastname, string gender, int age)
        {
            _dal.AddData(forename, lastname, gender, age);
            return RedirectToAction("Views");
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(string forename, string lastname, string gender, int age, int id)
        {
            _dal.UpdateData(forename, lastname, gender,age, id);
            return RedirectToAction("Views");
        }

        public IActionResult Delete(int id)
        {
            _dal.DeleteData(id);
            return RedirectToAction("Views","SQL");
        }

        public IActionResult Views()
        {
            DAL _dal = new();
            return View(_dal.GetData());
        }
    }
}
