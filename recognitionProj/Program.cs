using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using RecognitionProj.Controllers;
using recognitionProj;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Register controllers
builder.Services.AddControllers();

// Register Verifier as a singleton or transient service so it can be injected
builder.Services.AddSingleton<Verifier>();

// Register DatabaseHandler and pass connection string from configuration
// First, read the connection string from appsettings.json or environment variables

//var connectionString = "Server=SAIF\\SQLEXPRESS;Database=master;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
var connectionString = "Server=DEMONT-ML\\SQLEXPRESS;Database=master;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";




builder.Services.AddSingleton(new DatabaseHandler(connectionString));

var app = builder.Build();

// Serve static files (for files in wwwroot like /uploads)
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Assign a known URL
app.Urls.Add("http://localhost:5000");

// Map controller endpoints
app.MapControllers();

// Log that the application has started
Console.WriteLine("Server is running at http://localhost:5000");

// UseStaticFiles for serving Mspec3.html and other static files
app.UseStaticFiles();

// Run the web server asynchronously
var runTask = app.RunAsync();

// After the server starts, open the Mspec3.html from the server on localhost
Process.Start(new ProcessStartInfo
{
    FileName = "http://localhost:5000/Mspec3.html",
    UseShellExecute = true
});

// Await the server running task to prevent the application from exiting
await runTask;
