namespace Olive.Microservices.Hub.BoardComponent
{
    /// <summary>
    /// Represents a single item that is displayed to the user.
    /// </summary>
    public class BoardWidget
    {
        /// <summary>
        /// Url to which the user will be redirected for adding a new item.
        /// For relative Url to the current site use ~/my-url syntax.
        /// </summary>
        public string AddUrl { get; set; }

        /// <summary>
        /// Url to which the user will be redirected to manage these objects.
        /// For relative Url to the current site use ~/my-url syntax.
        /// </summary>
        public string ManageUrl { get; set; }

        /// <summary>
        /// Name of the search result. This is mandatory.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// colour of the widget
        /// </summary>
        public string Colour { get; set; }
        /// <summary>
        /// Permissions for acceess management
        /// </summary>
        public string Permissions { get; set; }
        /// <summary>
        /// Service of the component
        /// </summary>
        public string Service { get; set; }


    }
}
