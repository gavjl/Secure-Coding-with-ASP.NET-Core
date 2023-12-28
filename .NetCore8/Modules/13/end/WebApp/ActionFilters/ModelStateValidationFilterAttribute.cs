using Microsoft.AspNetCore.Mvc.Filters;

public class ModelStateValidationFilter : IAsyncActionFilter
{
    private readonly ILogger<ModelStateValidationFilter> _logger;

    public ModelStateValidationFilter(
        ILogger<ModelStateValidationFilter> logger)
    {
        _logger = logger;
    }

     public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid && context.HttpContext.Request.Method == "POST")
        {
            string modelErrors = "";
            var modelState = context?.ModelState;

            if (modelState is null)
                return;

            foreach(var key in modelState.Keys)
            {
                var keyEntry = modelState[key];
                if (keyEntry is not null && keyEntry.Errors.Count > 0)
                {
                    foreach (var error in keyEntry.Errors)
                    {
                        modelErrors += 
                            "Path: " + context.HttpContext.Request.Path +
                            " Key: " + key + 
                            " input: " + keyEntry.RawValue + Environment.NewLine;
                    }
                }
            }
            _logger.LogWarning("Input validation failure: {errors}.", modelErrors);
        }

        var result = await next();
    }
}