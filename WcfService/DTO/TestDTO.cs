using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan PassageTime { get; set; }

        //Foreign keys
        public int CategoryId { get; set; }

        //Navigation prop
        public CategoryDTO Category { get; set; }
    }
}