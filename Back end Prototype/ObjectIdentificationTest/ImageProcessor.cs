using Accord.Imaging;
using Accord.IO;
using ImageProcessor;
using ImageProcessor.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectIdentificationTest;

namespace ObjectIdentificationTest
{
    public class ImageProcessor
    {
        public ImageProcessor()
        { }

        public static bool ProcessImages(string folderLocation, string newFolderLocation, 
            int newWidth = 200, int newHeight = 200)
        {
            if (Directory.Exists(folderLocation) && Directory.GetDirectories(folderLocation).Any()
                && Directory.Exists(newFolderLocation))
            {
                foreach (var folder in Directory.GetDirectories(folderLocation))
                {
                    foreach (var filePath in Directory.GetFiles(folder))
                    {
                        var fileName = new FileInfo(filePath).Name;
                        var oldPath = Path.Combine(folder, fileName);
                        var newPath = Path.Combine(
                            Path.Combine(newFolderLocation, new DirectoryInfo(folder).Name),
                            fileName
                        );
                        ResizeEntropyCropAndSave(oldPath, newWidth, newHeight, newPath);
                    }
                }
                return true;
            }
            return false;
        }

        private static void ResizeEntropyCropAndSave(string inputPath, int width, int height, string newPath)
        {
            using (var inputImage = new Bitmap(inputPath))
            {
                var inStream = new MemoryStream(inputImage.ToByteArray(ImageFormat.Jpeg));
                using (var imageFactory = new ImageFactory())
                {
                    imageFactory.Load(inStream)
                                .Resize(new ResizeLayer(new Size(width, height), ResizeMode.Stretch))
                                .EntropyCrop()
                                .Resize(new ResizeLayer(new Size(width, height), ResizeMode.Stretch))
                                .Save(newPath);
                }
            }
        }
        
        private static Bitmap ResizeImage(Bitmap inputImage, int newHeight, int newWidth)
        {
            using (var inStream = new MemoryStream(inputImage.ToByteArray(ImageFormat.Jpeg)))
            {
                using (var outStream = new MemoryStream())
                {
                    using (var imageFactory = new ImageFactory())
                    {
                        imageFactory.Load(inStream)
                                    .Resize(new ResizeLayer(new Size(newWidth, newHeight)))
                                    .Save(outStream);
                    }
                    outStream.Position = 0;
                    inputImage = new Bitmap(outStream);
                }
            }
            return inputImage;
        }

        public static Images GetImagesAndLabels(string folderLocation)
        {
            var images = new Images();
            if (Directory.Exists(folderLocation) && Directory.GetDirectories(folderLocation).Any())
            {
                foreach (var folder in Directory.GetDirectories(folderLocation))
                {
                    var folderName = new DirectoryInfo(folder).Name;
                    foreach (var filePath in Directory.GetFiles(folder))
                    {
                        images.AddImage(new Bitmap(filePath), folderName);
                    }
                }
            }
            return images;
        }
    }
}
