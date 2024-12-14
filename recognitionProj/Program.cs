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

// Register Verifier as a singleton or transient service so it can be injected
builder.Services.AddSingleton<Verifier>();

var app = builder.Build();

// Assign a known URL
app.Urls.Add("http://localhost:5000");

// Map controller endpoints
app.MapControllers();

// Remove old direct usage of specController and verifier here for the ratio logic
// Because we will now run ratio logic inside SaveSpecialization after receiving the POST request

// Print "Hello World!" once
Console.WriteLine("Hello World!");

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
