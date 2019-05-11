using Accord.Imaging;
using Accord.IO;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Kernels;
using SharpLearning.Containers.Matrices;
using SharpLearning.RandomForest.Learners;
using SharpLearning.RandomForest.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ObjectIdentificationTest
{
    public class ModelProcessor
    {
        public ModelProcessor() { }

        public static MulticlassSupportVectorMachine<Linear> RunSVM(double[][] features, int[] labels, string modelSaveLocation = null)
        {
            var teacher = new MulticlassSupportVectorLearning<Linear>()
            {
                //Learner is aweful naming.. I can hardly talk but still
                Learner = (p) => new LinearDualCoordinateDescent() { Loss = Loss.L2 }
            };
            var svm = teacher.Learn(features, labels);
            var output = svm.Decide(features);
            double error = new ZeroOneLoss(labels).Loss(output);
            if(!string.IsNullOrEmpty(modelSaveLocation))
                Serializer.Save(obj: svm, path: modelSaveLocation);
            return svm;
        }

        public static MulticlassSupportVectorMachine<Linear> GetSvm(string modelLocation)
        {
            return Serializer.Load<MulticlassSupportVectorMachine<Linear>>(modelLocation);
        }

        public static double[] GetProbabilities(MulticlassSupportVectorMachine<Linear> svm, double[] featuresToTest)
        {
            return svm.Probabilities(featuresToTest);
        }

        public static double[][] GetSURFFeatures(Bitmap[] images, int maxFeatures, string modelSaveLocation = null)
        {
            Accord.Math.Random.Generator.Seed = 0;
            var bow = BagOfVisualWords.Create(numberOfWords: maxFeatures);
            bow.Learn(images);
            if(!string.IsNullOrEmpty(modelSaveLocation))
                Serializer.Save(obj: bow, path: modelSaveLocation);
            double[][] features = bow.Transform(images);
            return features;
        }

        public static double[][] GetSURFFeaturesFromExistingModel(Bitmap[] images, string modelLocation)
        {
            var bowModel = Serializer.Load<BagOfVisualWords>(modelLocation);
            bowModel.Learn(images);
            if (!string.IsNullOrEmpty(modelLocation))
                Serializer.Save(obj: bowModel, path: modelLocation);
            double[][] features = bowModel.Transform(images);
            return features;
        }

        //Singular
        public static double[] GetSURFFeaturesFromExistingModel(Bitmap testImage, string modelLocation)
        {
            var bowModel = Serializer.Load<BagOfVisualWords>(modelLocation);
            double[][] features = bowModel.Transform(new Bitmap[] { testImage });
            return features[0];
        }
    }
}
