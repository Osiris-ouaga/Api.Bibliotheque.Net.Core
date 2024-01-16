using Api.Bibiliotheque.Core.Net.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Bibiliotheque.Core.Net.Filters
{
    public class LoggingActionFilter : IActionFilter
    {
        private readonly ILogger<LoggingActionFilter> _logger;

        public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
        {
            _logger = logger;
        }

        //Après l'action on exécute cette partie
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogWarning($"Log de fin de l'appel API: {context.ActionDescriptor.DisplayName} à {DateTime.Now}");
        }

        //Avant l'action on exécute cette partie
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogWarning($"Log de l'appel API: {context.ActionDescriptor.DisplayName} à {DateTime.Now}");
        }
    }
}
