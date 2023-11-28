using MVCCRUD.DAL;
using MVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
	public class EmployeeController : BaseController
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        #region CRUD
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Createemp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmpModel empModel)
        {
			EmpDal.Create(empModel);
            return RedirectToAction("Read");
        }

        public ActionResult Createemp(EmpModel empModel)
        {
            EmpDal.Create(empModel);
            return RedirectToAction("Reademp");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
			EmpModel.Id = id;
			EmpModel = EmpDal.GetEmployee(EmpModel);
			return View("Create", EmpModel);
        }

        [HttpGet]
        public ActionResult Editemp(int id)
        {
            EmpModel.Id = id;
            EmpModel = EmpDal.GetEmployee(EmpModel);
            return View("Createemp", EmpModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
			EmpModel.Id = id;
			EmpModel = EmpDal.GetEmployee(EmpModel);
			return View("Create", EmpModel);
        }

        public ActionResult Edit(EmpModel empModel)
        {
			EmpDal.Update(empModel);
            return RedirectToAction("Read");
        }

        public ActionResult Editemp(EmpModel empModel)
        {
            EmpDal.Update(empModel);
            return RedirectToAction("Reademp");
        }

        public ActionResult Read()
        {
            List<EmpModel> empList = new List<EmpModel>();
			empList = EmpDal.Read();
            return View(empList);
        }

        public ActionResult Reademp()
        {
            List<EmpModel> empList = new List<EmpModel>();
            empList = EmpDal.Read();
            return View(empList);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
			EmpModel.Id = id;
			EmpModel = EmpDal.GetEmployee(EmpModel);
			return View(EmpModel);
        }

        [HttpPost]
        public ActionResult Delete(EmpModel empModel)
        {
			EmpDal.Delete(empModel);
            return RedirectToAction("Read");
        }
        #endregion
    }
}