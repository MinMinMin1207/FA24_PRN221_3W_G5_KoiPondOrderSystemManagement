﻿namespace KoiPondOrderSystemManagement.RazorWebApp
{
    public class Pagination<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public Pagination(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return PageIndex > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex < TotalPages;
            }
        }

        public static Pagination<T> Create(
            IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip(
                (pageIndex - 1) * pageSize)
                .Take(pageSize).ToList();
            return new Pagination<T>(items, count, pageIndex, pageSize);
        }
    }
}
