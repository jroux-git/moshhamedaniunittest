using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ActionResult DeleteEmployee(int id)
        {
            bool result = _employeeRepository.DeleteEmployee(id);

            if (result) 
            {
                return RedirectToAction("Employees");
            }
            else
            {
                return new NotFoundResult();
            }
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }

    public class NotFoundResult : ActionResult { }


}