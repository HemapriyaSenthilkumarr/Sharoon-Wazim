using EmployeeDetails.Data;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetails.Controllers
{
    public class EmpDetailsController : Controller
    {
        //create a obeject of appdbcnxt as a req to connect sqlDB to pgm

        private readonly ApplicationDbContext _db;


        //retriving data
        public EmpDetailsController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<EmpDetails> objDetailsList = _db.Details;
            return View(objDetailsList);
        }


        //GET
        //This method will retrieve the details of the property that we want to edit and display them in a form on the page.

        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empDetailsFromDb = _db.Details.Find(id);

            if (empDetailsFromDb == null)
            {
                return NotFound();
            }

            return View(empDetailsFromDb);
        }



        //POST
        //•	This is a POST method for the Edit option in a controller. It receives an object of type EmpDetails as a parameter, which represents the updated details of a property.
        //The method first checks if the data passed from the view is valid or not.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmpDetails obj)
        {
            if (ModelState.IsValid)
            {
                var empDetailsFromDb = _db.Details.Find(obj.Id);
                if (empDetailsFromDb == null)
                {
                    return NotFound();
                }

                // Update the properties of the existing object
                empDetailsFromDb.FirstName = obj.FullName.Split(" ")[0];
                empDetailsFromDb.LastName = obj.FullName.Split(" ")[1];
                empDetailsFromDb.Email = obj.Email;
                empDetailsFromDb.Department = obj.Department;
                empDetailsFromDb.Location = obj.Location;

                // Save changes to the database
                _db.Details.Update(empDetailsFromDb);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}