using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    [Authorize]
    public class Stu_InfController : Controller
    {
        private Student_IFEntities1 db = new Student_IFEntities1();

        // GET: Stu_Inf
        
        public ActionResult Index(int? i)
        {
            return View(db.Stu_Info.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Stu_Info stu_Info = db.Stu_Info.Find(id);

            if (stu_Info == null)
            {
                return HttpNotFound();
            }
            return View(stu_Info);
        }

        [Authorize (Roles = "admin, user")]
        public ActionResult Create()
        {
            var studentModel = new Stu_Info();

            return View(studentModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public ActionResult Create([Bind(Include = "Name,Age,Country,state,Gender,Pincode,DOB")] Stu_Info student)
        {
            if (ModelState.IsValid)
            {
               
                db.Stu_Info.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [Authorize(Roles = "admin")]
        // GET: Stu_Info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stu_Info stu_Info = db.Stu_Info.Find(id);
            
            if (stu_Info == null)
            {
                return HttpNotFound();
            }

            return View(stu_Info);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
       
        public ActionResult Edit([Bind(Include = "Id,Name,Age,Country,state,Gender,Pincode,DOB")] Stu_Info student)
        {
            if (ModelState.IsValid)
            {
                Stu_Info local = db.Stu_Info.Local.FirstOrDefault(f => f.Id == student.Id);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Stu_Info/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Stu_Info stu_Info = db.Stu_Info.Find(id);


            if (stu_Info == null)
            {
                return HttpNotFound();
            }
            return View(stu_Info);
        }

        // POST: Stu_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Stu_Info stu_Info = db.Stu_Info.Find(id);

            db.Stu_Info.Remove(stu_Info);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}