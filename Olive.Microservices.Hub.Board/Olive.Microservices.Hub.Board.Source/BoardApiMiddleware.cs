namespace Olive.Microservices.Hub.BoardComponent
{
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using System.Threading.Tasks;

    internal static class BoardApiMiddleware
    {
        internal static async Task Search<T>(HttpContext context) where T : BoardComponentsSource, new()
        {
            var id = context.Request.Param("boardItemId").OrEmpty();
            var type = context.Request.Param("boardtype").OrEmpty();
            if (id.IsEmpty() || type.IsEmpty()) return;

            var boardInstance = new T();
            await boardInstance.Process(context.User, id, type);
            var response = JsonConvert.SerializeObject(new { Results = boardInstance.Results, AddabledItems = boardInstance.AddableItems });
            await context.Response.WriteAsync(response);
        }
    }
}
