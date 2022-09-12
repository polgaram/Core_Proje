using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();
builder.Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();

builder.Services.AddScoped<IExperienceService, ExperienceManager>();
builder.Services.AddScoped<IExperienceDal, EfExperienceDal>();

builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

builder.Services.AddScoped<IPortfolioService, PortfolioManager>();
builder.Services.AddScoped<IPortfolioDal, EfPortfolioDal>();

builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IServiceDal, EfServiceDal>();

builder.Services.AddScoped<ISkillService, SkillManager>();
builder.Services.AddScoped<ISkillDal, EfSkillDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

builder.Services.AddScoped<IToDoListService, ToDoListManager>();
builder.Services.AddScoped<IToDoListDal, EfToDoListDal>();

builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddScoped<IWriterMessageService, WriterMessageManager>();
builder.Services.AddScoped<IWriterMessageDal, EfWriterMessageDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();



builder.Services.AddIdentity<WriterUser, WriterRole>(ops =>
{
    ops.Password.RequiredLength = 6;
    ops.Password.RequireLowercase = true; //küçük harf
    ops.Password.RequireNonAlphanumeric = true; //?_ gibi birþey bekle
    ops.Password.RequireUppercase = true;//büyük harf bekle
    ops.Password.RequireDigit = true; //0-9 arasý bir sayý

    ops.Lockout.MaxFailedAccessAttempts = 5;//max hatalý giriþ sayýsý
    ops.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);//kullanýcý ne kadar süre boyunca sisteme giriþ yapamasýn

    ops.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<Context>();

builder.Services.ConfigureApplicationCookie(cong =>
{
    cong.LoginPath = "/Writer/Login/Index";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
    );
});

app.Run();
