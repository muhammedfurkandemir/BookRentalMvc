namespace BookRentalApp.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public string Update(IFormFile file, string filePath, string root)
        {
            if (!File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file,root);
        }

        public string Upload(IFormFile file,string root)
        {
            using (FileStream fileStream=new FileStream(Path.Combine(root,file.FileName),FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return @"\img\"+file.FileName;
        }
    }
}
