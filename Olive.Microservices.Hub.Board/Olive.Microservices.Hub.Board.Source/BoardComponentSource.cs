using System.Security.Claims;
using System.Threading.Tasks;

namespace Olive.Microservices.Hub.BoardComponent
{
    partial class BoardComponentsSource
    {
        static string MakeAbsolute(string url) => Context.Current.Request().GetAbsoluteUrl(url);

        /// <summary>
        /// Performs the search for a specified user query.
        /// </summary>
        /// <param name="user">The current http user who initiated the search.</param>        
        /// <param name="id">board item id</param>        
        /// <param name="type">board type</param>        
        public abstract Task Process(ClaimsPrincipal user, string id, string type);
    }
}
