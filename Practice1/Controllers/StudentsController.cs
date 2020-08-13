using Practice1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice1.Controllers
{
    public class StudentsController : Controller
    {

        static List<Student> studentList = new List<Student>
        {
            new Student
            {
                StudentId = 1, Name = "Student1", DateOfBirth = new DateTime(2019, 1, 1), Gender = Gender.Female
            },
            new Student
            {
                StudentId = 2, Name = "Student2", DateOfBirth = new DateTime(2019, 2, 2), Gender = Gender.Male
            }
        };

        static int counter = 2;
        // GET: Students
        public ActionResult Index()
        {
            return View(studentList);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            Student student = studentList.Find(s => s.StudentId == id);

            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    counter++;
                    student.StudentId = counter;
                    studentList.Add(student);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            //var student = studentList.FirstOrDefault(s => s.StudentId == id);
            //var student = (from student1 in studentList where student1.StudentId == id select student1);
            var student = studentList.Find(s => s.StudentId == id);
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                student.StudentId = id;
                // TODO: Add update logic here
                if(student.StudentId <= counter)
                {
                    for (int i = 0; i < studentList.Count; i++)
                    {
                        Student s = studentList.ElementAt(i);
                        if (s.StudentId == student.StudentId)
                        {
                            studentList.RemoveAt(i);
                            student.StudentId = s.StudentId;
                            studentList.Insert(i, student);
                            break;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = studentList.Find(s => s.StudentId == id);
            if(student == null)
            {

            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                student.StudentId = id;
                // TODO: Add update logic here
                if (student.StudentId <= counter)
                {
                    for (int i = 0; i < studentList.Count; i++)
                    {
                        Student s = studentList.ElementAt(i);
                        if (s.StudentId == student.StudentId)
                        {
                            studentList.RemoveAt(i);
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult FindByGenre()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FindByGenre(Gender gender)
        {
            var students = studentList.FindAll(s => s.Gender == gender);
            return View(students);
        }
    }
}
