using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models
{
    public class Transaction {
        [KeyAttribute]
        public int TransactionId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Transaction() {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Date = DateTime.Now;
        }
        // public static void Transact(int amount) {
        //     Amount += amount;
        // }
    }
}