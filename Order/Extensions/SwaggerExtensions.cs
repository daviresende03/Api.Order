namespace Order.Extensions
{
    public static class SwaggerExtensions
    {
        public static void SwaggerConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Order API",
                    Description = "",
                    TermsOfService = new Uri("https://example.com/terms")
                });

                var xmlApiPath = Path.Combine(AppContext.BaseDirectory, $"{typeof(StartupBase).Assembly.GetName().Name}");
                xmlApiPath = xmlApiPath.Replace("Microsoft.AspNetCore.Hosting", "order.xml");
                c.IncludeXmlComments(xmlApiPath);
            });
        }
    }
}
