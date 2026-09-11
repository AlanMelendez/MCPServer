using MCPServer.Entities;
using MCPServer.Interfaces;

namespace MCPServer.Services
{
    public class PeopleRepositoryInMemory : IPeopleRepository
    {
        private List<Person> _people;

        public PeopleRepositoryInMemory()
        {
            _people = new List<Person>() { 
            
                new Person { Id = 1, Name = "John Doe", Active = true, Email = "john.doe@example.com", Salary = 40000 },
                new Person { Id = 2, Name = "Jane Smith", Active = false, Email = "jane.smith@example.com", Salary = 45000 },
                new Person { Id = 3, Name = "Alice Johnson", Active = true, Email = "alice.johnson@example.com", Salary = 50000 }

            };
        }

        public List<Person> GetAllPeople()
        {
            return _people.ToList();
        }

        public Person? GetPersonById(int id)
        {
            return _people.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateActive(int id, bool active)
        {
            var person = GetPersonById(id);

            if (person is null) return false;

            person.Active= active;

            return true;
        }
    }
}
