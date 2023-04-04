using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_pp.Model
{
    internal class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string budget { get; set; }
    }
}
