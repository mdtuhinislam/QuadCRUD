using Microsoft.AspNetCore.Mvc;
using QuadCRUD.Interfaces;
using QuadCRUD.Models;
using QuadCRUD.ViewModels;

namespace QuadCRUD.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentServices _studentServices;
        private readonly IClassService _classService;
        public StudentController(IStudentServices studentServices, IClassService classService)
        {
            _studentServices = studentServices;
            _classService = classService;
        }
        public async Task<IActionResult> Create()
        {
            var classes = await _classService.GetAll();
            return View(classes);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            
            if (ModelState.IsValid)
            {
                student.ModificationDate = null;
                student.CreatedDate = DateTime.Now;
                await _studentServices.Add(student);
            }
            else return BadRequest("Error!");
            var students = await _studentServices.GetAllWithAssociateClasses();
            return View("List", students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _studentServices.GetByIdWithAssociateClasses(id);
            if (student == null)
                return View("No Item Found!");
            var classes = await _classService.GetAll();
            var AllClasses = classes;
            ViewBag.SelectedClassId = student.ClassId;
            var studentVm = new StudentVM()
            {
                Name = student.Name,
                Gender = student.Gender,
                DOB = student.DOB,
                ClassId = student.ClassId,
                Classes = (List<Class>)  AllClasses
            };
            return View("Edit", studentVm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentServices.UpdateAsync(student);
            }
            if (student == null)
                return View("No Item Found!");
            var students = await _studentServices.GetAllWithAssociateClasses();
            return View("List", students);
        }
        public async Task<IActionResult> List()
        {
            var students = await _studentServices.GetAllWithAssociateClasses();
            return View("List", students);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var student = await _studentServices.GetByIdWithAssociateClasses(id);
            if (student == null)
                return View("No Item Found!");

            return View("View", student);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _studentServices.GetByIdWithAssociateClasses(id);
            if (student == null)
                return View("No Item Found!");
            _studentServices.Remove(student);
            var students = await _studentServices.GetAllWithAssociateClasses();
            return View("List", students);
        }
    }
}
