namespace Olive
{
    using Microsoft.AspNetCore.Builder;
    using Olive.Microservices.Hub.BoardComponent;

    public static class BoardComponentsExtensions
    {
        public static IApplicationBuilder UseBoardComponents<T>(this IApplicationBuilder @this)
            where T : BoardComponentsSource, new()
        {
            @this.Map("/api/board-components",
                app => app.Run(context => BoardApiMiddleware.Search<T>(context)));

            return @this;
        }
    }
}
