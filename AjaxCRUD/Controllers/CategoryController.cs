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
            
            return View();
        }

        [HttpGet]
        public JsonResult CategoryList()
        {
            var category = _db.Category.ToList();
            return Json(new { data = category }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
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

        ////GET
        //public IActionResult Create()
        //{
        //    return View();
        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken] //prevents from cross-site forgery attack
        //public IActionResult Create(Category obj)
        //{
        //    if (obj.Name == obj.DisplayOrder.ToString())
        //    {
        //        // ModelState.AddModelError("CustomeError", "The DisplayOrder cannot exactly match the Name.");

        //        //Display the error in Name field as well.
        //        ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _db.Category.Add(obj);
        //        _db.SaveChanges();
        //        TempData["success"] = "Category created successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);
        //}



        //For Edit the categories
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Category.Find(id);
            //var categoryFromDbFirst = _db.Category.FirstOrDefault(u => u.Id == id);
            //var categoryFromSingle = _db.Category.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //prevents from cross-site forgery attack
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //Display the error in Name field as well.
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        //For delete the categories
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Category.Find(id);
            //var categoryFromDbFirst = _db.Category.FirstOrDefault(u => u.Id == id);
            //var categoryFromSingle = _db.Category.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        //[HttpPost, ActionName("Delete")] //Explicitely give the different name
        [ValidateAntiForgeryToken] //prevents from cross-site forgery attack
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}