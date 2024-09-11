using StudyAPI.Infrastructure.Data;
using StudyAPI.Model;

namespace StudyAPI.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDataContext _context; //uso do underline para dizer que a variavel é privada
        public EmployeeRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee? GetById(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
