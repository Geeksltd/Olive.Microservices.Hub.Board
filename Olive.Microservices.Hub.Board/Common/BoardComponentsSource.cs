namespace Olive.Microservices.Hub.BoardComponent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Olive;
    /// <summary>
    /// The base class for a custom application-specific source provider.
    /// </summary>
    public abstract partial class BoardComponentsSource
    {
        internal List<BoardComponentsResult> Results = new();
        internal List<BoardComponentsType> AddableItems = new();
        internal List<BoardWidget> Widgets = new();

        /// <summary>
        /// Adds an item to the results.
        /// </summary>
        protected void Add(BoardComponentsResult result)
        {
            if (result == null) return;

            if (result.Url.IsEmpty())
                throw new ArgumentException("Url cannot be empty in a search result.");

            if (result.Name.IsEmpty())
                throw new ArgumentException("Title cannot be empty in a search result.");

            result.Url = FixUrl(result.Url);
            result.IconUrl = FixUrl(result.IconUrl);
            Results.Add(result);
        }

        /// <summary>
        /// Adds an item to the results.
        /// </summary>
        protected void Add(BoardComponentsType result)
        {
            if (result == null) return;

            if (result.AddUrl.IsEmpty() && result.ManageUrl.IsEmpty())
                throw new ArgumentException("At least one of AddUrl and ManagerUrl must be provided.");

            if (result.Name.IsEmpty())
                throw new ArgumentException("Title cannot be empty in a search result.");

            result.AddUrl = FixUrl(result.AddUrl);
            result.ManageUrl = FixUrl(result.ManageUrl);
            result.IconUrl = FixUrl(result.IconUrl);
            AddableItems.Add(result);
        }

        static string FixUrl(string url)
        {
            if (url.OrEmpty().StartsWith("~/")) return MakeAbsolute(url.TrimStart('~'));
            else return url;
        }
        protected void Add(BoardWidget result)
        {
            if (result == null) return;

            if (result.AddUrl.IsEmpty() && result.ManageUrl.IsEmpty())
                throw new ArgumentException("At least one of AddUrl and ManagerUrl must be provided.");

            if (result.Name.IsEmpty())
                throw new ArgumentException("Title cannot be empty in a search result.");

            result.AddUrl = FixUrl(result.AddUrl);
            result.ManageUrl = FixUrl(result.ManageUrl);
            Widgets.Add(result);
        }
        /// <summary>
        /// Adds an item to the results.
        /// <paramref name="url">For relative Url to the current site use ~/my-url syntax.</paramref>
        /// </summary>
        protected void Add(string name, string url)
        {
            Add(new BoardComponentsResult { Name = name, Url = url });
        }
    }
}