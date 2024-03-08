using Ideawrit.Services.Extensions;



var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorPages();
//Eklendi...
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//builder.Services.AddAutoMapper();
builder.Services.LoadMyServices();
//

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
//Eklendi...
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );
app.MapDefaultControllerRoute();
app.UseStatusCodePages();
app.UseDeveloperExceptionPage();
//app.UseStaticFiles();

