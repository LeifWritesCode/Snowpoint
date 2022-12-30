using Microsoft.Extensions.DependencyInjection;

namespace Snowpoint
{
    /// <summary>
    /// Extensions methods to configure an <see cref="IServiceCollection"/> for <see cref="ISnowpoint"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <see cref="ISnowpoint"/> and related services to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="self">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The configurable <see cref="ISnowpointBuilder"/>.</returns>
        public static ISnowpointBuilder AddSnowpoint(this IServiceCollection self)
        {
            var builder = new SnowpointBuilder();
            self.AddTransient(sp => builder.Build());
            return builder;
        }
    }
}
