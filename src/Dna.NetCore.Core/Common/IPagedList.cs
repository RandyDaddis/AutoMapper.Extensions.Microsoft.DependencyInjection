using System.Collections.Generic;

namespace Dna.NetCore.Core.Common
{
    public interface IPagedList<T> : IList<T>
	{
		/// <summary>
		/// designates the current page in a range of pages (IE: page X of Y)
		/// </summary>
		int PageIndex { get; }
		/// <summary>
		/// the maximum number of items to be displayed on a single page
		/// </summary>
		int PageSize { get; }
        /// <summary>
        /// the total number of items in the list
        /// </summary>
        int TotalSize { get; }
        /// <summary>
		/// the total number of pages required to display the complete list of items
		/// </summary>
		int TotalPages { get; }
		/// <summary>
		/// determine if the current page is the last page
		/// </summary>
		bool HasNextPage { get; }
		/// <summary>
		/// determine if the current page is the first page
		/// </summary>
		bool HasPreviousPage { get; }
	}
}
