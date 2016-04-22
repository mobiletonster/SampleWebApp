using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApp.Models
{
    public class PagedList
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get { return (TotalRecords / PageSize); } }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public object Result { get; set; }
    }
}