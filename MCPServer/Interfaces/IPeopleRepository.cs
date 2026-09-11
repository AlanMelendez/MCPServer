using MCPServer.Entities;

namespace MCPServer.Interfaces
{
    public interface IPeopleRepository
    {
        bool UpdateActive(int id, bool active);
        Person? GetPersonById(int id);
        List<Person> GetAllPeople();
    }
}
