using SignalR.App.HubContext;

namespace SignalR.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program program = new();

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();

            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            //app.UseEndpoints(endpoint =>
            //{
            //    endpoint.MapHub<ChatHub>("/chat-hub");
            //});

            app.MapHub<ChatHub>("/chat-hub");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

           
            app.Run();
        }
    }
}
