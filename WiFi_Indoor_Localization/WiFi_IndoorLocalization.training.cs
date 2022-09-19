﻿// This file was auto-generated by ML.NET Model Builder.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.LightGbm;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace WiFi_Indoor_Localization
{
    public partial class WiFi_IndoorLocalization
    {
        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process. For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"RSSI1", @"RSSI1"),new InputOutputColumnPair(@"RSSI2", @"RSSI2"),new InputOutputColumnPair(@"RSSI3", @"RSSI3"),new InputOutputColumnPair(@"RSSI4", @"RSSI4"),new InputOutputColumnPair(@"RSSI5", @"RSSI5"),new InputOutputColumnPair(@"RSSI6", @"RSSI6"),new InputOutputColumnPair(@"RSSI7", @"RSSI7")})      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"RSSI1",@"RSSI2",@"RSSI3",@"RSSI4",@"RSSI5",@"RSSI6",@"RSSI7"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:@"Room",inputColumnName:@"Room"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.LightGbm(new LightGbmMulticlassTrainer.Options(){NumberOfLeaves=133,NumberOfIterations=12,MinimumExampleCountPerLeaf=83,LearningRate=0.999999776672986,LabelColumnName=@"Room",FeatureColumnName=@"Features",ExampleWeightColumnName=null,Booster=new GradientBooster.Options(){SubsampleFraction=0.0343208668055186,FeatureFraction=0.618594466292299,L1Regularization=2.88262813948258E-07,L2Regularization=3.98863478617147E-06},MaximumBinCountPerFeature=328}))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:@"PredictedLabel",inputColumnName:@"PredictedLabel"));

            return pipeline;
        }
    }
}