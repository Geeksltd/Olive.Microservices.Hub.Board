using System;
using System.Security.Principal;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace Olive.Microservices.Hub.BoardComponent
{
    partial class BoardComponentsSource : IHttpHandler
    {
        static string MakeAbsolute(string url) => HttpContext.Current.Request.GetAbsoluteUrl(url);

        bool IHttpHandler.IsReusable => false;

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            var id = context.Request["boardItemId"].OrEmpty();
            var type = context.Request["boardtype"].OrEmpty();

            if (id.IsEmpty() || type.IsEmpty()) return;

            Process(context.User, id, type).GetAwaiter().GetResult();
            var response = new JavaScriptSerializer().Serialize(new
            {
                Results,
                AddabledItems = AddableItems
            });

            context.Response.ContentType = "text/json";
            context.Response.Write(response);
        }

        /// <summary>
        /// Performs the search for a specified user query.
        /// </summary>
        /// <param name="user">The current http user who initiated the search.</param>     
        /// <param name="id">board item id</param>        
        /// <param name="type">board type</param>     
        public abstract Task Process(IPrincipal user, string id, string type);
    }
}