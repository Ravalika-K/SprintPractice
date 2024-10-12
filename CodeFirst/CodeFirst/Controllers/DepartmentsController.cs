using CodeFirst.CF;
using CodeFirst.IService;
using CodeFirst.Models;
using CodeFirst.Service;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    [Route("Departments")]
    public class DepartmentsController : Controller
    {
        //REPOSITORY PATTERN
        
        private readonly IDepartmentService _service;
        public DepartmentsController(IDepartmentService service)
        {
            _service = service;
        }
        //[Route("")]
        [Route("department")]
        [Route("Alldepartment")]
        public IActionResult Index()
        {
            return View(_service.GetAllDepartments());
        }
        [Route("department/{departmentid}/details")]
        public IActionResult Details(int departmentid)
        {
           Department D = _service.GetDepartmentById(departmentid);
            return View(D);
        }
       
        public IActionResult Delete(int departmentid)
        {
            Department D = _service.GetDepartmentById(departmentid);
            return View(D);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int departmentid)
        {
            try
            {
                string result=_service.DeleteDepartment(departmentid);
                if(result== "Derpartmemt removed"){
                    return RedirectToAction("Index");
                }
                return View(result); 
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IActionResult Update(int departmentid)
        {
            Department D = _service.GetDepartmentById(departmentid);
            return View(D);
        }
        [HttpPost]
        public IActionResult Update(Department department)
        {
            string res= _service.UpdateDepartment(department);
            
            if(res== "Updated")
            {
                return RedirectToAction("Index");
            }
            return View(res);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
                _service.AddNewDepartment(department);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }




        //------**************************************************************************
        //private readonly ApplicationDB _context;
        //public DepartmentsController(ApplicationDB context)
        //{
        //    _context = context;
        //}
        //public IActionResult Index()
        //{
        //    List<Department> departments = _context.Departments.ToList();
        //    return View(departments);
        //}
        //public IActionResult Details(int departmentid)
        //{
        //    Department department = _context.Departments.Where(c => c.DepartmentId == departmentid).FirstOrDefault();
        //    return View(department);
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Department department)
        //{
        //    if(department!=null)
        //    {
        //        _context.Departments.Add(department);
        //        _context.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
