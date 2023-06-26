using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using SistemaDeGestaoEscolar.Common;

namespace SistemaDeGestaoEscolar.WebApp
{
    public static class GestaoExceptionMiddlewareExtension
    {
        public static void UseGestaoException(this IApplicationBuilder app, ILog logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Use(async (context, next) =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.Error($"[{context.Request.Path}]: {contextFeature.Error.Message} - {contextFeature.Error.StackTrace}");
                    }

                    await next();
                });
            });
        }
    }
}