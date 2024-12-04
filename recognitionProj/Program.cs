namespace recognitionProj;
using RecognitionProj.Controllers;
public class Program
{
    public static void Main(string[] args)//this is the main
    {
        // open the database connection

        var connectionString = "Host=my_host;Username=my_user;Password=my_pw;Database=my_db";//placeholders
        DatabaseHandler dbHandler = new(connectionString);
        SpecializationController controller = new SpecializationController();
        dbHandler.Query("SELECT * FROM my_table");//placeholder query
        for ( int i=0; i<10; i++)
        {
            //hello world
            Console.WriteLine("Hello World!");
        }
        
    }
}
