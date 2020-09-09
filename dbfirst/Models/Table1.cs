using System;
using System.Collections.Generic;

namespace dbfirst
{
    public partial class Table1
    {
        public int Id { get; set; }
        public char? Name { get; set; }
        public char? LastName { get; set; }
        public char? Department { get; set; }
        public DateTime? Date { get; set; }
    }
}
