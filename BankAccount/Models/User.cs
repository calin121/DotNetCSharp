using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models {
    public class User {
        [KeyAttribute]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Transaction> Transactions { get; set; }
        public User() {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Balance = 0.00;
            Transactions = new List<Transaction>();

        }
    }
}