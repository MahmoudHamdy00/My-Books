namespace My_Books.Data.Paging
{
    public class PaginatedList<T> : List<T>
    {
        public int pageIndex { get; set; }
        public int totalPages { get; set; }
        public PaginatedList(List<T> items/*, int count, int pageIndex, int pageSize*/)
        {
            // this.pageIndex = pageIndex;
            //  this.totalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }
        /* public bool hasPrev
         {
             get
             {
                 return this.pageIndex > 1;
             }
         }
         public bool hasNext
         {
             get
             {
                 return this.pageIndex < this.totalPages;
             }
         }*/
        public static PaginatedList<T> create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items/*, count, pageIndex, pageSize*/);
        }
    }
}
