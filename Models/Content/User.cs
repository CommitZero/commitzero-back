using System.ComponentModel.DataAnnotations;

namespace CommitZeroBack.Models {
    public class User {
        [Key]
        public int id {get; set;}
        public string username {get; set;}
        public string password {get; set;}
        public string sessionip {get; set;}
        public string sessiontoken {get; set;}
        public string sessionexpiration {get; set;}
    }
}