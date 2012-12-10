using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChecksAndBalances.Data.Models.Enum;

namespace ChecksAndBalances.Data.Models
{
    public class ArticleState
    {
        public int Id { get; set; }
        public int StateId { get; set; }

        [NotMapped]
        public State State
        {
            get
            {
                return (State)StateId;
            }
            set
            {
                StateId = (int)value;
            }
        }
    }
}
