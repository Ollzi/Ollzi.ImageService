using System;
using System.Runtime.Serialization;

namespace Ollzi.ImageService.Contracts
{
    [DataContract]
    public class ImageMetaData
    {
        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public string FileDate { get; set; }
    }
}
