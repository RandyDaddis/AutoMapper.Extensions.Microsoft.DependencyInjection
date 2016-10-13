using System.Collections.Generic;
using System.Linq;

namespace NetCore.Core.Common
{
	public class PagedList<T> : List<T>, IPagedList<T>
	{
        #region ctor

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            TotalSize = source.Count();
            TotalPages = TotalSize / pageSize;

            if (TotalSize % pageSize > 0)
            {
                TotalPages++;
            }

            PageIndex = pageIndex;
            PageSize = pageSize;

            this.AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize));
        }

        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            TotalSize = source.Count();
            TotalPages = TotalSize / pageSize;

            if (TotalSize % pageSize > 0)
            {
                TotalPages++;
            }

            PageIndex = pageIndex;
            PageSize = pageSize;

            this.AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            TotalSize = source.Count();
            TotalPages = TotalSize / pageSize;

            if (TotalSize % pageSize > 0)
            {
                TotalPages++;
            }

            PageIndex = pageIndex;
            PageSize = pageSize;

            this.AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray());
        }

        #endregion

        #region Public Properties

        public int PageIndex { get; private set; }
		public int PageSize { get; private set; }
		public int TotalSize { get; private set; }
		public int TotalPages { get; private set; }

        public bool HasNextPage
        {
            get { return (PageIndex + 1 <= TotalPages); }
        }

        public bool HasPreviousPage 
		{
			get { return (PageIndex > 1); }
		}
		
		#endregion
	}
}
