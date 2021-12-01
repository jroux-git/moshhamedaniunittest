namespace TestNinja.Mocking
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private EmployeeContext _db;

        public EmployeeRepository()
        {
            _db = new EmployeeContext();
        }

        public bool DeleteEmployee(int id)
        {
            using (_db)
            {
                var employee = _db.Employees.Find(id);

                if (employee == null)
                    return false;
                
                _db.Employees.Remove(employee);
                int result = _db.SaveChanges();

                return result > 0;
            }
        }
    }
}
