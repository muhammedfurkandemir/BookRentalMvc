namespace BookRentalApp.Models
{
    public interface IRentalRepository:IRepository<Rental>
    {
        void Update(Rental rental);

        void Save();
    }
}
