using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using RecognitionProj.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using recognitionProj;

var builder = WebApplication.CreateBuilder(args);

// Register controllers
builder.Services.AddControllers();

var app = builder.Build();

// Assign a known URL
app.Urls.Add("http://localhost:5000");

// Map controller endpoints
app.MapControllers();

// Create controller and verifier instances as in your original code
SpecializationController specController = new SpecializationController();
Verifier verifier = new Verifier();

// Print "Hello World!" once
Console.WriteLine("Hello World!");

// Retrieve High Diploma specializations from the controller
var result = specController.GetSpecializationByType("High Diploma");

if (result is OkObjectResult okResult 
    && okResult.Value is List<Specialization> specializations 
    && specializations.Count > 0)
{ 
    var highDiplomaSpec = specializations[0];
    
    Console.WriteLine(highDiplomaSpec.Color);

    specController.SaveSpecialization(highDiplomaSpec);
}
else
{
    Console.WriteLine("No High Diploma specializations found.");
}

// Serve static files (make sure Mspec3.html is in wwwroot)
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
