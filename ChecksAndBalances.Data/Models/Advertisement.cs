using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChecksAndBalances.Data.Storage;

namespace ChecksAndBalances.Data.Models
{
    public class Advertisement : IEntity
    {
        public Advertisement()
        {
            Articles = new List<Article>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ClientName { get; set; }
        public int SortOrder { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
