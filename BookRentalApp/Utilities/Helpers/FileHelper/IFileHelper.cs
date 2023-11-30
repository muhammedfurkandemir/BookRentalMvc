namespace BookRentalApp.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {

        string Update(IFormFile file,string filePath, string root);
        string Upload(IFormFile file,string root);

    }
}
