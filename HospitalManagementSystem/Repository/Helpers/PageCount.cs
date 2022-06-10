using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Helpers
{
    public static class PageCount
    {
        public static int GetPageCount(int count, int take)
        {
            var pageCount = (int)Math.Ceiling((decimal)count / take);
            return pageCount;
        }
    }
}
