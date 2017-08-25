using System.IO;

namespace Ollzi.ImageService.Business
{
    public interface IImageProvider
    {
        string[] GetImageFiles(string basePath);
    }

    public class ImageProvider : IImageProvider
    {
        public string[] GetImageFiles(string basePath)
        {
            return Directory.GetFiles(basePath, "*.png,*.jpg", SearchOption.AllDirectories);
        }
    }
}
