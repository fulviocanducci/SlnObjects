using Microsoft.AspNetCore.Mvc;
using PrjObjects.Models;
namespace PrjObjects.Controllers
{
   public class PeopleController : Controller
   {
      private readonly EfDatabase _ef;

      public PeopleController(EfDatabase ef)
      {
         _ef = ef;
      }

      public ActionResult Index()
      {
         return View(_ef.People);
      }

      public ActionResult Details(long id)
      {
         return View(_ef.People.Find(id));
      }

      public ActionResult Create()
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create(People people)
      {
         try
         {
            if (ModelState.IsValid)
            {
               _ef.People.Add(people);
               _ef.SaveChanges();
               return RedirectToAction(nameof(Edit), new { people.Id });
            }
            return View(people);
         }
         catch
         {
            return View();
         }
      }

      public ActionResult Edit(long id)
      {
         return View(_ef.People.Find(id));
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit(People people)
      {
         try
         {
            if (ModelState.IsValid)
            {
               _ef.Update(people);
               _ef.SaveChanges();
               return RedirectToAction(nameof(Edit), new { people.Id });
            }
            return View(people);
         }
         catch
         {
            return View();
         }
      }

      public ActionResult Delete(long id)
      {
         return View(_ef.People.Find(id));
      }

      [HttpPost]
      [ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public ActionResult DeleteById(long id)
      {
         try
         {
            People people = _ef.People.Find(id);
            if (people != null)
            {
               _ef.People.Remove(people);
               _ef.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }
   }
}
