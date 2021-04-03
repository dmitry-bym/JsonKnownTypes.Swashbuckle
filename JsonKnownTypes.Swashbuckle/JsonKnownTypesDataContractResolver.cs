using System;
using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Newtonsoft;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace JsonKnownTypes.Swashbuckle
{
    public class JsonKnownTypesDataContractResolver : ISerializerDataContractResolver
    {
        private readonly NewtonsoftDataContractResolver _resolver;
        public JsonKnownTypesDataContractResolver(NewtonsoftDataContractResolver resolver)
        {
            _resolver = resolver;
        }
        
        public DataContract GetDataContractForType(Type type)
        {
            var contract = _resolver.GetDataContractForType(type);
            
            if (JsonKnownTypesCache.TypeToDiscriminator.TryGetValue(type, out var fieldName))
            {
                var discriminatorProperty = new DataProperty(fieldName, typeof(string));

                var properties = new List<DataProperty>
                {
                    discriminatorProperty
                };
                
                properties.AddRange(contract.ObjectProperties.ToList());
                
                return DataContract.ForObject(contract.UnderlyingType,
                    properties,
                    contract.ObjectExtensionDataType,
                    contract.ObjectTypeNameProperty,
                    contract.ObjectTypeNameValue,
                    contract.JsonConverter);
            }

            return contract;
        }
    }
}
