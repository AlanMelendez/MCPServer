var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMcpServer().WithHttpTransport();

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
