using MCPServer.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMcpServer().WithHttpTransport().WithToolsFromAssembly();

builder.Services.AddUserServices();

builder.Services.AddCors(cors =>
{
    cors.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

app.UseCors();
app.MapMcp("/mcp");

app.Run();
