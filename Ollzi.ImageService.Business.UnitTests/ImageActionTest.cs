using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ollzi.ImageService.Business.Action;

namespace Ollzi.ImageService.Business.UnitTests
{
    [TestClass]
    public class ImageActionTest
    {
        private ImageAction Action { get; set; }
        private Mock<IImageProvider> ImageProviderMock { get; set; }

        [TestInitialize]
        public void Setup()
        {
            ImageProviderMock = new Mock<IImageProvider>();
            Action = new ImageAction(ImageProviderMock.Object, string.Empty);
        }

        [TestMethod]
        public void GivenFolderContainsMoreThan30Pictures_WhenGettingImages_Then20RandomPicturesIsReturned()
        {
            // Arrange
            ImageProviderMock.Setup(m => m.GetImageFiles(It.IsAny<string>())).Returns(GetFileNames);

            // Act
            var images = Action.GetImages();

            // Assert
            Assert.AreEqual(20, images.Count());
        }

        private string[] GetFileNames()
        {
            return new[]
            {
                "1.png", "2.png", "3.png", "4.png", "5.png", "6.png", "7.png", "8.png", "9.png", "10.png", "11.png",
                "12.png", "13.png", "14.png", "15.png", "16.png", "17.png", "18.png", "19.png", "20.png", "21.png", "22.png",
                "23.png", "24.png", "25.png", "26.png", "27.png", "28.png", "29.png", "30.png", "31.png", "32.png", "33.png",
                "a.png", "b.png", "c.png", "d.png", "e.png", "f.png",
                "g.png", "h.png", "i.png", "j.png", "k.png", "l.png",
                "m.png", "n.png", "o.png", "p.png", "q.png", "r.png"
            };
        }
    }
}
