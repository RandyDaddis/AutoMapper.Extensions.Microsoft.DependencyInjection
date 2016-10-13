using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ISomeService>(sp => new FooService(5));
            services.AddAutoMapper(typeof(Source));
            var provider = services.BuildServiceProvider();
            provider.GetService<IMapper>();

            foreach (var service in services)
            {
                Console.WriteLine(service.ServiceType + " - " + service.ImplementationType);
            }
            Console.ReadKey();
        }
    }
}
