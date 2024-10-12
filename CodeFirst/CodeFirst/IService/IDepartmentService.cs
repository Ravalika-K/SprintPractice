using CodeFirst.Models;

namespace CodeFirst.IService
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        Department AddNewDepartment(Department department);
        string DeleteDepartment(int id);
        string UpdateDepartment(Department department);
        Department GetDepartmentById(int id);
    }
}


