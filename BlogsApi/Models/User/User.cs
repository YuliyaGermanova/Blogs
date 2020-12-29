using System;

namespace BlogsApi.Models
{
    public class User
    {
        public int Id {get;set;}

        public string Login { get; set; }

        private string PasswordHash { get; set; }

        public string getPassHash() {
            return PasswordHash;
        }

        public void setPassHash(string hash) {
            PasswordHash = hash;
        }
    }
}