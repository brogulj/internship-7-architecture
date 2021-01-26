using EFCore.Data.Entities;
using EFCore.Data.Entities.Models;
using EFCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable

namespace EFCore.Domain.Repositories
{
    public class EmployeeRepository : BaseRepository
    {
        public EmployeeRepository(EFCoreDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(Employee employee)
        {
            DbContext.Employees.Add(employee);

            return SaveChanges();
        }

        public ResponseResultType Edit(Employee employee, int employeeId)
        {
            var employeeDb = DbContext.Employees.Find(employeeId);
            if (employeeDb == null)
            {
                return ResponseResultType.NotFound;
            }
            employeeDb.FirstName = employee.FirstName;
            employeeDb.LastName = employee.LastName;
            employeeDb.StartOfShift = employee.StartOfShift;
            employeeDb.EndOfShift = employee.EndOfShift;
            return SaveChanges();
        }

        public ResponseResultType ToggleAvailability(bool availability, int employeeId)
        {
            var employee = DbContext.Employees.Find(employeeId);
            employee.Availability = availability;
            return SaveChanges();
        }
        public ICollection<Employee> GetAll()
        {
            return DbContext.Employees
                .ToList();
        }
        public Employee? FindById(int Id)
        {
            var employeeIds = new List<int>();
            foreach (var employee in DbContext.Employees)
            {
                employeeIds.Add(employee.Id);
            }
            if (!employeeIds.Contains(Id))
            {
                return null;
            }
            return DbContext.Employees.Find(Id);
        }
    }
}
