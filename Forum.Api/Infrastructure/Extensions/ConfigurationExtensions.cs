using Forum.Api.Infrastructure.Configurations;

namespace Forum.Api.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static JwtAuthOptions ConfigureJwtAuthOptions(this IConfiguration configuration, IServiceCollection services)
        {
            var section = configuration.GetSection("JwtAuthOptions");
            services.Configure<JwtAuthOptions>(section);

            var authOptions = section.Get<JwtAuthOptions>();
            return authOptions;
        }
    }
}
