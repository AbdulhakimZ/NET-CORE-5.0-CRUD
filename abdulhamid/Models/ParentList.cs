using System;
using System.Collections.Generic;

#nullable disable

namespace abdulhamid.Models
{
    public partial class ParentList
    {
        public ParentList()
        {
            ChildLists = new HashSet<ChildList>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int? IsFinished { get; set; }

        public virtual ICollection<ChildList> ChildLists { get; set; }
    }
}
