using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Ollzi.ImageService
{
    public class ImageService : IImageService
    {
        public IEnumerable<ImageMetaData> GetImages()
        {
            
        }
    }
}
