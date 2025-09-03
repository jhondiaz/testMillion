using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using TestMillion.WebExceptions.Interface;
using TestMillion.Entities.Exceptions;


namespace TestMillion.WebExceptions
{
    public class GeneralExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var Exception = context.Exception as GeneralException;
            return SetResult(context, StatusCodes.Status500InternalServerError, Exception.Message, Exception.Detail);
        }
    }
}
