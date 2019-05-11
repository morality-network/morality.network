using Accord.Imaging;
using Accord.Imaging.Filters;
using Accord.MachineLearning.DecisionTrees;
using Accord.Vision.Detection;
using ImageProcessor;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Filters.EdgeDetection;
using ImageProcessor.Imaging.Filters.Photo;
using SharpLearning.Containers.Matrices;
using SharpLearning.RandomForest.Learners;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectIdentificationTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var featureCount = 100;

            var rawImageFolder = "";
            var newImageFolder = "";
            var modelPath = "/model.mdl";
            var featuresPath = "/extractedFeatures.ftr";

            //Build model images
            ImageProcessor.ProcessImages(rawImageFolder, newImageFolder);

            //Create new
            var images = ImageProcessor.GetImagesAndLabels(newImageFolder);
            var features = ModelProcessor.GetSURFFeatures(images.ImageList, featureCount, featuresPath);           
            var svmModel = ModelProcessor.RunSVM(features, images.ClassifiersAsNumber, modelPath);

            //Already created one         
            var newImageToClassifyPath = "/cat.jpg";
            var imageToAdd = new Bitmap(newImageToClassifyPath);
            var existingSvmModel = ModelProcessor.GetSvm(modelPath);
            var newImageAsFeatureArray = ModelProcessor.GetSURFFeaturesFromExistingModel(imageToAdd, featuresPath);
            var result = ModelProcessor.GetProbabilities(existingSvmModel, newImageAsFeatureArray);

            Console.Read();
        }
    }
}
