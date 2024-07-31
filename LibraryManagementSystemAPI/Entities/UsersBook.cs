namespace LibraryManagementSystemAPI.Entities
{
    public class UsersBook
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime RentedDay { get; set; } = DateTime.Now;
        public int TotalPenaltyFee { get; set; }
        public bool IsReturned { get; set; } = false;
        public Book Book { get; set; }
        public User User { get; set; }     
    }
}
