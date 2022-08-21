using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticeAdila.Api.Controller
{
    public class RestaurantTwoController : Controller
    {
        // GET: RestaurantTwoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RestaurantTwoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RestaurantTwoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantTwoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantTwoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestaurantTwoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantTwoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RestaurantTwoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
