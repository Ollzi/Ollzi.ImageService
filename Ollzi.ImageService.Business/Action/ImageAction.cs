using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Ollzi.ImageService.Contracts;

namespace Ollzi.ImageService.Business.Action
{
    public class ImageAction
    {
        private readonly IImageProvider _imageProvider;
        private readonly string _basePath;

        public ImageAction()
            :this(new ImageProvider(), ConfigurationManager.AppSettings["BasePath"])
        {
            
        }

        public ImageAction(IImageProvider imageProvider, string basePath)
        {
            _imageProvider = imageProvider;
            _basePath = basePath;
        }

        public IEnumerable<ImageMetaData> GetImages()
        {
            var imageFiles = _imageProvider.GetImageFiles(_basePath);
            var random = new Random();
            var numberOfFilesToRandomize = imageFiles.Length >= 20 ? 20 : imageFiles.Length;

            var randomizedFiles = new List<ImageMetaData>();

            while (randomizedFiles.Count < numberOfFilesToRandomize)
            {
                var index = random.Next(0, numberOfFilesToRandomize);

                if (randomizedFiles.All(m => m.FileName != imageFiles[index]))
                {
                    randomizedFiles.Add(new ImageMetaData
                    {
                        FileName = imageFiles[index]
                    });
                }
            }

            return randomizedFiles;
        }
    }
}
