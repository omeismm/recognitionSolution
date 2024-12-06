namespace recognitionProj;
using RecognitionProj.Controllers;
using System;
using System.Diagnostics;
public class Program
{
    public static void Main(string[] args)
    {
        // open the database connection

        //var connectionString = "Host=my_host;Username=my_user;Password=my_pw;Database=my_db";//placeholders
        //DatabaseHandler dbHandler = new(connectionString);
        SpecializationController specController = new SpecializationController();
        //dbHandler.Query("SELECT * FROM my_table");//placeholder query
        Verifier verifier = new Verifier();
        for (int i = 0; i < 10; i++)
        {
            //hello world
            Console.WriteLine("Hello World!");
        }

        //open Mspec2.html and keep the program running
        Process.Start(new ProcessStartInfo
        {
            FileName = "Mspec2.html",
            UseShellExecute = true
        });

        //in memory list to store specializations temporarily
        List<Specialization> SpecializationList = specController.SpecializationList;

        while (true)
        {
             specController.GetSpecializationByType("High Diploma");
            verifier.HighDiplomaRatio(SpecializationList[0]);
            Console.WriteLine(SpecializationList[0].Color);
            //todo, make a controller for the color and send it back to the frontend
        }
    }
}
