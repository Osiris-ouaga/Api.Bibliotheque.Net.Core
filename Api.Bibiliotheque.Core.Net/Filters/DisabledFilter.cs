using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Bibiliotheque.Core.Net.Filters
{
    public class DisabledFilter : Attribute, IResourceFilter
    {
        //S'exécute après l'appel de la méthode
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

        //S'exécute avant l'appel de la méthode
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //Si la route contient certain chemin alors on avertit l'utilisateur qu'elle n'est plus disponible
            if (context.HttpContext.Request.Path.Value.Contains("maroute"))
            {
                context.Result = new BadRequestObjectResult(
                    new
                    {
                        result = new[] { "Cette méthode n'est plus disponible" }
                    });
            }
        }
    }
}
