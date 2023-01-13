using StudentDAL;
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
        private Student_IFEntities db = new Student_IFEntities();

        // GET: Stu_Inf
        /// <summary>
        /// returns the home view
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public ActionResult Index(int? i)
        {
            return View(db.Stu_Info.ToList());
        }

       /// <summary>
       /// returns the details of individual student
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
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
        /// <summary>
        /// api for creating new user
        /// </summary>
        /// <returns></returns>
        [Authorize (Roles = "admin")]
        public ActionResult Create()
        {
            var studentModel = new Stu_Info();

            return View(studentModel);
        }

        /// <summary>
        /// saving details of new user in database
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>

        [HttpPost]
        [Authorize(Roles = "admin")]
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

        /// <summary>
        /// api for editing user details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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

        /// <summary>
        /// api to delete details of student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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