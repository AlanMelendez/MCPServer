using Microsoft.Extensions.AI;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace MCPServer.Prompts
{
    [McpServerPromptType]
    public class PeoplePrompts
    {
        [McpServerPrompt, Description("Prompt to get the list of all registered people")]
        public static ChatMessage GetAllPeople() => new(ChatRole.User, """
            Retrive the complete list of people using the available tool.
            Then presen the information in easy English words and in a clear and organized way, using a table format with the following columns: Id, Name, Active, Email, Salary.
            """);

        [McpServerPrompt, Description("Prompt to retrieve a person by id.")]
        public static ChatMessage GetById(
         [Description("Id of the person to retrieve.")] int id)
         => new(
         ChatRole.User,
         $"""
            Find the person with id {id} using the available tool.

            If the person exists:
            - show their information in English,
            - indicate whether they are active or not.

            If the person does not exist:
            - clearly indicate it.  
        """);

        [McpServerPrompt, Description("Prompt to activate a person.")]
        public static ChatMessage ActivatePerson(
       [Description("Id of the person.")] int id)
       => new(
           ChatRole.User,
           $"""
                Activate the person with id {id} using the available tool.
                You must send active = true.

                Then explain in English whether the operation was successful or not.
                """
       );

        [McpServerPrompt, Description("Prompt to deactivate a person.")]
        public static ChatMessage DeactivatePerson(
            [Description("Id of the person.")] int id)
            => new(
                ChatRole.User,
                $"""
                    Deactivate the person with id {id} using the available tool.
                    You must send active = false.

                    Then explain in English whether the operation was successful or not.
                    """
            );

    }

}
