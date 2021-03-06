# JsonKnownTypes.Swashbuckle

[![nuget](https://img.shields.io/nuget/v/JsonKnownTypes.Swashbuckle?style=flat-square)](https://www.nuget.org/packages/JsonKnownTypes.Swashbuckle)
[![downloads](https://img.shields.io/nuget/dt/JsonKnownTypes.Swashbuckle?style=flat-square)](https://www.nuget.org/packages/JsonKnownTypes.Swashbuckle)
[![lisence](https://img.shields.io/badge/lisence-MIT-green?style=flat-square)](https://github.com/dmitry-bym/JsonKnownTypes.Swashbuckle/blob/main/LICENSE)

<a href="https://www.buymeacoffee.com/dmitry.bym" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/yellow_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>

Add swashbuckle support to the project with JsonKnownTypes

- [Documentation](#Documentation)
- [License](#License)

## Requirements
- [Swashbuckle.AspNetCore.Newtonsoft](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [JsonKnownTypes](https://github.com/dmitry-bym/JsonKnownTypes) `>= 0.5.4`



## Documentation
To add JsonKnowTypes support in swashbuckle use `AddSwaggerGenJsonKnownTypesSupport` extension method
```c#
public void ConfigureServices(IServiceCollection services)
{
    services
        .AddMvc()
        .AddNewtonsoftJson();
    
    services
        .AddSwaggerGen()
        .AddSwaggerGenNewtonsoftSupport()
        .AddSwaggerGenJsonKnownTypesSupport();
}
```

It will add discriminator field and will use base class
```c#
[JsonConverter(typeof(JsonKnownTypesConverter<Animal>))]
public record Animal(int Age);
```
Example Value | Schema in SwaggerUI:
```json
{ "$type": "string", "age": 0 }
```

Also you can use it with custom discriminator
```c#
[JsonConverter(typeof(JsonKnownTypesConverter<Animal>))]
[JsonDiscriminator(Name = "kind")]
public record Animal(int Age);
```
Example Value | Schema in SwaggerUI:
```json
{ "kind": "string", "age": 0 }
```

## License

Authored by: Dmitry Kaznacheev (dmitry-bym)

This project is under MIT license. You can obtain the license copy [here](https://github.com/dmitry-bym/JsonKnownTypes.Swashbuckle/blob/main/LICENSE).

This work using work of :
 - James Newton-King, author of Json.NET. https://www.newtonsoft.com/json
 - Richard Morris, author of Swashbuckle.AspNetCore https://github.com/domaindrivendev/Swashbuckle.AspNetCore
