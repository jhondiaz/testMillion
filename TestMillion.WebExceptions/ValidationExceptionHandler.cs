using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Threading.Tasks;
using TestMillion.WebExceptions.Interface;


namespace TestMillion.WebExceptions
{
    public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var Exception = context.Exception as ValidationException;
            StringBuilder builder = new StringBuilder();
            foreach (var error in Exception.Errors)
            {
                builder.AppendLine($"Propiedad: {error.PropertyName}, Error: {error.ErrorMessage}");
            }
            return SetResult(context, StatusCodes.Status400BadRequest, "Error en los datos de entrada", builder.ToString());
        }
    }
}
