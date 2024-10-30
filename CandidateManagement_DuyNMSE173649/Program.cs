using DAO;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Microsoft.Extensions.DependencyInjection;
using CandidateManagement_DuyNMSE173649.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IHraccountServ, HraccountServ>();
builder.Services.AddScoped<IHraccountRepo, HraccountRepo>();
builder.Services.AddScoped<ICandidateProfileServ, CandidateProfileServ>();
builder.Services.AddScoped<ICandidateProfileRepo, CandidateProfileRepo>();
builder.Services.AddScoped<IJobPostingServ, JobPostingServ>();
builder.Services.AddScoped<IJobPostingRepo, JobPostingRepo>();
builder.Services.AddDbContext<CandidateManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapGet("/", async context =>
    {
        context.Response.Redirect("/Login");
    });
});

app.UseAuthorization();

app.MapRazorPages();
app.Run();
