using CodeFirst.CF;
using CodeFirst.IService;
using CodeFirst.Models;

namespace CodeFirst.Service
{
    public class DepartmentService : IDepartmentService
    {
        public ApplicationDB _context;
        public DepartmentService(ApplicationDB context)
        {
            _context = context;
        }
        public Department AddNewDepartment(Department department)
        {
            if(department!=null)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return department;
            }
            return null;
        }

        public string DeleteDepartment(int id)
        {
            try 
            {
                if (id != null || id != 0)
                {
                    Department D = _context.Departments.Where(c => c.DepartmentId == id).FirstOrDefault();
                    if (D != null)
                    {
                        _context.Departments.Remove(D);
                        _context.SaveChanges();
                        return "Derpartmemt removed";
                    }
                    else
                    {
                        return "Department id not found";
                    }
                }
                else
                {
                    return "id should not be null";
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            try
            {
                Department D = _context.Departments.Where(c => c.DepartmentId == id).FirstOrDefault();
                if (D != null)
                {
                    return D;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string UpdateDepartment(Department department)
        {
            try
            {
                Department D = _context.Departments.Where(c => c.DepartmentId == department.DepartmentId).FirstOrDefault();
                if (D != null)
                {
                    D.DepartmentName = department.DepartmentName;
                    _context.SaveChanges();
                    return "Updated";
                }
                return "Not found";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
