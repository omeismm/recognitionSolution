namespace recognitionProj;

public class Program
{
    public static void Main(string[] args)//this is the main
    {
        // open the database connection

        var connectionString = "Host=my_host;Username=my_user;Password=my_pw;Database=my_db";//placeholders
        DatabaseHandler dbHandler = new(connectionString);
        dbHandler.Query("SELECT * FROM my_table");//placeholder query

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
