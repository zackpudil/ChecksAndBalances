using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChecksAndBalances.Data.Models.Enum;

namespace ChecksAndBalances.Data.Models
{
    public class Article
    {
        public int Id { get; set; }

        [StringLength(int.MaxValue)]
        public string Content { get; set; }

        public string Authors { get; set; }
        public string Sources { get; set; }

        public bool Published { get; set; }
        public DateTime DatePublished { get; set; }

        public ICollection<int> States { get; set; }
        public IEnumerable<State> AvaliableStates
        {
            get
            {
                return States.Cast<State>();
            }
        }
    }
}
