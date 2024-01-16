using Api.Bibiliotheque.Core.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Bibiliotheque.Core.Net.Filters
{
    public class FormattingResultFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            //Permet de formatter la sortie du résultat ou autres ...
            if(!(context.Result is EmptyResult))
            {
                var item = context.Result as ObjectResult;
                context.Result = new JsonResult(new HttpResult<object>()
                {
                    StatutCode = item.StatusCode,
                    IsSuccess = (item.StatusCode == 200 || item.StatusCode == 201) ? true : false,
                    Data = item.Value
                });
            }

            var resultContext = await next();
        }
    }
}
