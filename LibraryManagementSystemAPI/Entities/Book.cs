using System.Security.Principal;

namespace LibraryManagementSystemAPI.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double DailyPenaltyFee { get; set; }
        public int MaxRentDay { get; set; }
     
        public int PageCount { get; set; }
        public bool IsRented { get; set; }
        public bool IsDeleted { get; set; }
    }
}
