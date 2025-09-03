using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using TestMillion.WebExceptions.Interface;
using TestMillion.WebExceptions;


namespace TestMillion.WebExceptions
{
  
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, IExceptionHandler> _exceptionHandlers;
        public ApiExceptionFilterAttribute(IDictionary<Type, IExceptionHandler> exceptionHandlers) =>
            _exceptionHandlers = exceptionHandlers;
        public override void OnException(ExceptionContext context)
        {
            Type ExceptionType = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(ExceptionType))
            {
                _exceptionHandlers[ExceptionType].Handle(context);
            }
            else
            {
                new ExceptionHandlerBase().SetResult(context, StatusCodes.Status500InternalServerError, "Se presento un error al procesar", "");
            }
        }
    }
}
