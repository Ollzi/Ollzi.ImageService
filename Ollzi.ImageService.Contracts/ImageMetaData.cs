using System;
using System.Runtime.Serialization;

namespace Ollzi.ImageService.Contracts
{
    [DataContract]
    public class ImageMetaData
    {
        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public DateTime FileDate { get; set; }
    }
}
