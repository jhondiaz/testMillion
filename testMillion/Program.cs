using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TestMillion.Entities.Exceptions;
using TestMillion.IoC;
using TestMillion.UseCases.Mappings;
using TestMillion.WebExceptions;
using TestMillion.WebExceptions.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTestMillionDependencies(builder.Configuration);

builder.Services.AddControllers(options =>
            options.Filters.Add(new ApiExceptionFilterAttribute(new Dictionary<Type, IExceptionHandler>
            {
                { typeof(GeneralException),new GeneralExceptionHandler()},
                { typeof(ValidationException),new ValidationExceptionHandler()}
             }))
            );

var key = builder.Configuration.GetSection("Jwt:Key").Value;

var ValidAudiences = builder.Configuration.GetSection("Jwt:ValidAudiences").Get<string[]>() ?? [];

var ValidIssuer = builder.Configuration.GetSection("Jwt:ValidIssuer").Value;

var Authority = builder.Configuration.GetSection("Jwt:Authority").Value;

builder.Services.AddAuthentication()
    .AddJwtBearer(x =>
    {
        // x.Authority = Authority;
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key ?? "")),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = ValidIssuer,
            ValidAudience = string.Join(",", ValidAudiences),

        };
    }); ;



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TesMillion.Api", Version = "v1" });
//});


builder.Services.AddSwaggerGen(options =>
{

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
             { jwtSecurityScheme, Array.Empty<string>() }
          });

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "TesMillion.Api", Version = "v1.0.0" });

  

});


var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapping());
}, loggerFactory);

mapperConfig.CompileMappings();


IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);


var app = builder.Build();
 app.UseSwagger();
 app.UseSwaggerUI();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
   
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
