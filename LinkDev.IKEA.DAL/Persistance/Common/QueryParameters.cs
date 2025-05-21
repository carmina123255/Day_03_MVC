using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistance.Common
{
   public  class QueryParameters
    {
        private const int MaxPageSize = 20;
        public int PageIndex { get; set; }
        private int _pageSize = 10;
        public int TotalCount { get; set; }
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}
