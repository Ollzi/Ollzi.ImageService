using System.IO;
using System.Linq;

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
            var searchPattern = new[] {"*.png", "*.jpg"};

            return searchPattern.SelectMany(x => Directory.GetFiles(basePath, x, SearchOption.AllDirectories)).ToArray();
        }
    }
}
