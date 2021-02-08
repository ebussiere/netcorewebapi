using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using netcorewebapi.Data.Models;

namespace netcorewebapi.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(new Employee()
                        {
                            FirstName = "Eddy",
                            LastName = "Bussiere",
                        },
                        new Employee()
                        {
                            FirstName = "John",
                            LastName = "Doe",
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
