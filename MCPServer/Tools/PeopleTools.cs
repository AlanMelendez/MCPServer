using MCPServer.Entities;
using MCPServer.Interfaces;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace MCPServer.Tools
{
    [McpServerToolType()]
    public class PeopleTools
    {
        IPeopleRepository _peopleRepository;

        private PeopleTools() { }

        public PeopleTools(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }


        [McpServerTool, Description("Gets the list of all registered people")]
        public List<Person> GetAllPeople()
        {
            return _peopleRepository.GetAllPeople();
        }

        [McpServerTool, Description("Gets a person by their ID")]
        public Person GetPeople([Description("Gets a person by their ID")]int id)
        {

            var person= _peopleRepository.GetPersonById(id) ?? throw new ArgumentException("Person not found");
            return person;
        }

        [McpServerTool, Description("Updates the active status of a person by their ID")]
        public bool UpdatePersonActiveStatus(int id, bool isActive)
        {
            return _peopleRepository.UpdateActive(id, isActive);
        }
    }
}
