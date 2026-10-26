using Microsoft.EntityFrameworkCore;
using HtthLab01.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký SchoolContext để kết nối SQL Server
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 2. Khởi tạo dữ liệu mẫu (gọi DbInitializer) khi chạy ứng dụng
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DbInitializer.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "StudentList",
    pattern: "Admin/Student/List",
    defaults: new { controller = "Student", action = "Index" });

app.MapControllerRoute(
    name: "StudentAdd",
    pattern: "Admin/Student/Add",
    defaults: new { controller = "Student", action = "Create" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();