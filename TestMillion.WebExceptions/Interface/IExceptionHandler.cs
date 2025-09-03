using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;


namespace TestMillion.WebExceptions.Interface
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}
