using System;
using System.Collections.Generic;

#nullable disable

namespace abdulhamid.Models
{
    public partial class ChildList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int? ParentId { get; set; }

        public virtual ParentList Parent { get; set; }
    }
}
