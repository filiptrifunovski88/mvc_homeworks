using MovieRental.Domain.Enums;

namespace MovieRental.Dtos.ViewModels
{
    public class ReturnRentalItemViewModel
    {
        public int RentalId { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public DateTime RentedOn { get; set; }
    }
}
