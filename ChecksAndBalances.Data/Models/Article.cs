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
        public Article()
        {
            States = new List<ArticleState>();
            Tags = new List<CategoryTag>();
            Comments = new List<Comment>();
        }
        public int Id { get; set; }

        [StringLength(int.MaxValue)]
        public string Content { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public string Authors { get; set; }
        public string Sources { get; set; }

        public bool Published { get; set; }
        public DateTime DatePublished { get; set; }

        public int Views { get; set; }
        public bool SpotLighted { get; set; }

        public ICollection<ArticleState> States { get; set; }
        public ICollection<CategoryTag> Tags { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
