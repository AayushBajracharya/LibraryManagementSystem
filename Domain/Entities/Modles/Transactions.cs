namespace LibraryManagementSystem.Modles
{
    public class Transactions
    {
        public int TransactionId { get; set; }
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }

        // Additional fields for display
        public string StudentName { get; set; }
        public string BookTitle { get; set; }
        public string Username { get; set; }
    }
}
