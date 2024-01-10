using FayyadTechnicalBackend.Context;
using FayyadTechnicalBackend.Models;
using FayyadTechnicalBackend.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace FayyadTechnicalBackend.Repository
{
    public class EmployeesRepository
    {
        private readonly MyContext context;
        public EmployeesRepository(MyContext context)
        {
            this.context = context;
        }
        public IEnumerable<Employees> Get()
        {
            return context.Employees.ToList();
        }
        public int Insert(EmployeesVM employee)
        {
            var insert = new Employees
            {
              Name = employee.Name,
              Email = employee.Email,
              phone = employee.phone
            };
            context.Employees.Add(insert);
            var setemployee = context.SaveChanges();
            return setemployee;
        }
        public int Update(Employees employee)
        {
            context.Entry(employee).State = EntityState.Modified;
            var result = context.SaveChanges();
            return result;
        }
    }
}
