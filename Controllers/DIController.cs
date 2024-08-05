using DotNetCoreRepoPatternDI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreRepoPatternDI_New.Controllers
{
    public class DIController : Controller
    {
        private readonly ITransient _itransientService1;
        private readonly ITransient _itransientService2;


        private readonly IScoped _iscopedService1;
        private readonly IScoped _iscopedService2;

        private readonly ISingleton _isingletonService1;
        private readonly ISingleton _isingletonService2;

        public DIController(ITransient itransientService1, ITransient itransientService2, IScoped iscopedService1, IScoped iscopedService2, ISingleton isingletonService1, ISingleton isingletonService2)
        {
            _itransientService1 = itransientService1;
            _itransientService2 = itransientService2;

            _iscopedService1 = iscopedService1;
            _iscopedService2 = iscopedService2;

            _isingletonService1 = isingletonService1;
            _isingletonService2 = isingletonService2;
                
        }

        // GET: DIController
        public ActionResult Index()
        {
            ViewBag.transient1 = _itransientService1.GetOperationId().ToString();
            ViewBag.transient2 = _itransientService2.GetOperationId().ToString();

            ViewBag.scoped1 = _iscopedService1.GetOperationId().ToString();
            ViewBag.scoped2 = _iscopedService2.GetOperationId().ToString();

            ViewBag.singleton1 = _isingletonService1.GetOperationId().ToString();
            ViewBag.singleton2 = _isingletonService2.GetOperationId().ToString();


            return View();
        }

        // GET: DIController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DIController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DIController/Create
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

        // GET: DIController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DIController/Edit/5
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

        // GET: DIController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DIController/Delete/5
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
