using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Newtonsoft;
using Swashbuckle.AspNetCore.SwaggerGen;

#if (NETSTANDARD2_0)
using MvcNewtonsoftJsonOptions = Microsoft.AspNetCore.Mvc.MvcJsonOptions;
#endif

namespace JsonKnownTypes.Swashbuckle
{
    public static class JsonKnownTypesExtensions
    {
        public static IServiceCollection AddSwaggerGenJsonKnownTypesSupport(this IServiceCollection services)
        {
            return services.Replace(
                ServiceDescriptor.Transient<ISerializerDataContractResolver>(s =>
                {
                    var serializerSettings = s.GetRequiredService<IOptions<MvcNewtonsoftJsonOptions>>().Value?.SerializerSettings
                                             ?? new JsonSerializerSettings();

                    var newtonsoftResolver = new NewtonsoftDataContractResolver(serializerSettings);
                    return new JsonKnownTypesDataContractResolver(newtonsoftResolver);
                }));
        }
    }
}
