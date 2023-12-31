﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC.Controllers
{
    public class HomeController : Controller
    {
        MVCCRUDDBEntities _context = new MVCCRUDDBEntities();
        public ActionResult Index()
        {
            var listOfData = _context.Student.ToList();
            return View(listOfData);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Create(Student model) 
        { 
            _context.Student.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id) 
        { 
            var data = _context.Student.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student model)
        {
            var data =  _context.Student.Where(x => x.StudentId == model.StudentId).FirstOrDefault();
            if (data != null)
            {
                data.StudentdName = model.StudentdName;
                data.StudentdAge = model.StudentdAge;
                data.StudentdCity = model.StudentdCity;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.Student.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = _context.Student.Where(x => x.StudentId == id).FirstOrDefault();
            _context.Student.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Delete Sucessfully";
            return RedirectToAction("Index");
        }
    }

}