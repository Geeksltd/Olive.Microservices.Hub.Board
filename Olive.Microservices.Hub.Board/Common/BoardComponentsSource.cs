namespace Olive.Microservices.Hub.BoardComponent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The base class for a custom application-specific source provider.
    /// </summary>
    public abstract partial class BoardComponentsSource
    {
        internal List<BoardComponentsResult> Results = new List<BoardComponentsResult>();
        internal List<BoardComponentsAddableItem> AddableItems = new List<BoardComponentsAddableItem>();

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
        protected void Add(BoardComponentsAddableItem result)
        {
            if (result == null) return;

            if (result.Url.IsEmpty())
                throw new ArgumentException("Url cannot be empty in a search result.");

            if (result.Name.IsEmpty())
                throw new ArgumentException("Title cannot be empty in a search result.");

            result.Url = FixUrl(result.Url);
            result.IconUrl = FixUrl(result.IconUrl);
            AddableItems.Add(result);
        }

        static string FixUrl(string url)
        {
            if (url.OrEmpty().StartsWith("~/")) return MakeAbsolute(url.TrimStart('~'));
            else return url;
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