using MCPServer.DTOs;
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

        [McpServerTool, Description("Activates or deactivates a person by their identifier")]
        public OperationResultDTO UpdatePersonActiveStatus(
            [Description("Identifier of the perdon to update")]
            int id,
            [Description("Indicates whether the person will be active (true) or inactive (false).")]
            bool isActive)
        {
            var updateResult = _peopleRepository.UpdateActive(id, isActive);

            if(!updateResult) return new OperationResultDTO(false, $"Failed to update the active status of the person with ID {id}. Please check if the Id person exists.");
            return new OperationResultDTO(true, "Person active status updated successfully.");
        }
    }
}
