using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3_P._2_N01180209.Models;
using System.Diagnostics;

namespace Assignment3_P._2_N01180209.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        //GET: /Teacher/List
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.TeacherList(SearchKey);
            return View(Teachers);
        }



        //GET: /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }


        //GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }


        //POST: /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            // Instantiating 
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);

            return RedirectToAction("List");
        }

        //GET : /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        //POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime HireDate, decimal Salary)
        {
            //Identify that this method is runnning
            //Identify the inputs provided from the form 

            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);

            if (TeacherFname == "" || TeacherLname == "" || EmployeeNumber == "")
            {
                return RedirectToAction("New");
            }
            else
            {

                //Create new Teacher Object
                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;


                TeacherDataController controller = new TeacherDataController();
                controller.AddTeacher(NewTeacher);

                return RedirectToAction("List");
            }

        }

        //GET : /Teacher/Update/{id}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(int id)
        {

            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }

        /// <summary>
        /// Receives a POST request containing information about an existing teacher in the system, with new values. Conveys this information to the API, 
        /// and redirects to the "Teacher Show" page of our updated teacher.
        /// </summary>
        /// <param name="id">For update Teacher ID</param>
        /// <param name="TeacherFname">For update Teacher Last Name</param>
        /// <param name="TeacherLname">For update Teacher First Name</param>
        /// <param name="EmployeeNumber">For update Teacher Number</param>
        /// <param name="HireDate">For update Hire Date</param>
        /// <param name="Salary">For update the Salary</param>
        /// <returns> A dynamic webpage which provides the current information of the teacher.</returns>
        /// <example>
        /// POST : /Teacher/Update/{id}
        /// FORM DATA/ POST DATA/ REQUEST BODY
        /// {
        /// "TeacherFname":"Leo",
        /// "TeacherLname":"Nguyen",
        /// "EmployeeNumber":"N123",
        /// "HireDate":"DD-MM-YYYY",
        /// "Salary":"28.90"
        /// }
        /// </example>
        //POST: //Teacher/Update/{id}
        [HttpPost]
        public ActionResult Update (int id, string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime HireDate, decimal Salary)
        {

            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFname = TeacherFname;
            TeacherInfo.TeacherLname = TeacherLname;
            TeacherInfo.EmployeeNumber = EmployeeNumber;
            TeacherInfo.HireDate = HireDate;
            TeacherInfo.Salary = Salary;


            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id,TeacherInfo);

            //redirect to see the consequence 
            return RedirectToAction("Show/" + id);
        }
    }
}