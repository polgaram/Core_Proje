using Core_Proje_Api.DAL.ApiContext;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_Api.ApiDependency
{
    public static class Dependency
    {
        public static void AddIdentityLayer(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddDbContext<Context>(ops =>
            {
                ops.UseSqlServer(Configuration.GetConnectionString("MyIdentityConnectionString"), ops =>
                {
                    ops.MigrationsAssembly(typeof(Context).Assembly.FullName);
                });
            });

            //Services.AddIdentity<WriterUser, WriterRole>(ops =>
            //{
            //    ops.Password.RequiredLength = 6;
            //    ops.Password.RequireLowercase = true; //küçük harf
            //    ops.Password.RequireNonAlphanumeric = true; //?_ gibi birşey bekle
            //    ops.Password.RequireUppercase = true;//büyük harf bekle
            //    ops.Password.RequireDigit = true; //0-9 arası bir sayı

            //    ops.Lockout.MaxFailedAccessAttempts = 5;//max hatalı giriş sayısı
            //    ops.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);//kullanıcı ne kadar süre boyunca sisteme giriş yapamasın

            //    ops.User.RequireUniqueEmail = true;

            //}).AddEntityFrameworkStores<Context>();




        }
    }
}
