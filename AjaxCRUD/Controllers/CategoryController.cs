using AjaxCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookAjaxWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var category = _db.Category.ToList();
            return View();
        }

        [HttpGet]
        public JsonResult CategoryList()
        {
            var category = _db.Category.ToList();
            return new JsonResult(category);
        }

        public JsonResult Create()
        {
            var data = _db.Category.ToList();
            return new JsonResult(data);
        }

        //POST
        [HttpPost]
        public JsonResult Create(Category obj)
        {
            var cat = new Category()
            {
                Name = obj.Name,
                DisplayOrder = obj.DisplayOrder
            };
            _db.Category.Add(cat);
            _db.SaveChanges();
            return new JsonResult("Data is Saved");
        }

        //For Edit the categories
        //GET
        public JsonResult Edit(int id)
        {
            var data = _db.Category.SingleOrDefault(u => u.Id == id);
            return new JsonResult(data);
        }

        //POST
        [HttpPost]
        public JsonResult Update(Category obj)
        {
            _db.Category.Update(obj);
            _db.SaveChanges();
            return new JsonResult("Category Updated!");
        }

        //For delete the categories
        public JsonResult Delete(int? id)
        {
            var category = _db.Category.SingleOrDefault(u => u.Id == id);
            _db.Category.Remove(category);
            _db.SaveChanges();
            return new JsonResult("Data Deleted!");
        }
    }
}