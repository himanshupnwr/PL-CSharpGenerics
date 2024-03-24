using BrainCoffee.Data;
using BrainCoffee.Entities;
using BrainCoffee.Repository;

namespace BrainCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            employeeRepository.ItemAdded += EmployeeAdded_Event;
            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var organizationRepository = new GenericRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAllToConsole(organizationRepository);

            Console.ReadLine();
        }

        private static void EmployeeAdded_Event(object? sender, Employee employee)
        {
            Console.WriteLine($"Employee Added => { employee.FirstName}");
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            var saraManager = new Manager { FirstName = "Sara" };
            var saraManagerCopy = saraManager.Copy();
            managerRepository.Add(saraManager);

            if (saraManagerCopy is not null)
            {
                saraManagerCopy.FirstName += "_Copy";
                managerRepository.Add(saraManagerCopy);
            }

            managerRepository.Add(new Manager { FirstName = "Henry" });
            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Julia" });
            employeeRepository.Add(new Employee { FirstName = "Anna" });
            employeeRepository.Add(new Employee { FirstName = "Thomas" });
            employeeRepository.Save();
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            var organzations = new[]
            {
                new Organization { Name = "Pluralsight" },
                new Organization { Name = "Globomantics" }
            };
            AddBatch(organizationRepository, organzations);
            //organizationRepository.Add(new Organization { Name = "Pluralsight" });
            //organizationRepository.Add(new Organization { Name = "Globomantics" });
            organizationRepository.Save();
        }

        /*private static void AddBatch(IRepository<Organization> organizationRepository, Organization[] organzations)
        {
            foreach (var item in organzations)
            {
                organizationRepository.Add(item);
            }
            organizationRepository.Save();
        }*/
        //Converted the above method to a generic method
        private static void AddBatch<T>(IWriteRepository<T> repository, T[] items)
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }
    }
}