using System.ComponentModel.DataAnnotations;

namespace CommitZeroBack.Models {
    public class Post {
        [Key]
        public int id {get; set;}
        public int author_id {get; set;}
        public string title {get; set;}
        public string cathegory {get; set;}
        public string author {get; set;}
        public string content {get; set;}
        public string description {get; set;}
        public string updated_at {get; set;}
        public string created_at {get; set;}
    }
}