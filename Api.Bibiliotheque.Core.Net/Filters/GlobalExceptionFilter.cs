using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Bibiliotheque.Core.Net.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        //Se déclenche sur chaque exception de nos controllers
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message);
            context.Result = new ContentResult
            {
                Content = $"Une exception grave est arrivée : {context.Exception.ToString()}"
            };
        }
    }
}
