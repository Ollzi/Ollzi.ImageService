using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using Ollzi.ImageService.Contracts;

namespace Ollzi.ImageService
{
    [ServiceContract]
    public interface IImageService
    {
        [OperationContract]
        IEnumerable<ImageMetaData> GetImages();
    }
}
