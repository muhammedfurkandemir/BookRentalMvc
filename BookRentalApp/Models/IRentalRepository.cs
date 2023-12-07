namespace BookRentalApp.Models
{
    public interface IRentalRepository:IRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
        void Update(Rental rental);

        void Save();
    }
}
