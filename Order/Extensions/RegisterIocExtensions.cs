using Order.Application.Applications;
using Order.Application.Interfaces;
using Order.Domain.Interfaces.Repositories;
using Order.Domain.Interfaces.Services;
using Order.Domain.Services;
using Order.Infra.Repositories;

namespace Order.Extensions
{
    public static class RegisterIocExtensions
    {
        public static void RegisterIoc(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IClientApplication, ClientApplication>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
        }

    }
}
