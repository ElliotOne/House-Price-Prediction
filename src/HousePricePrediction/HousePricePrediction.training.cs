﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace HousePricePrediction
{
    public partial class HousePricePrediction
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
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"Area", @"Area"),new InputOutputColumnPair(@"Age", @"Age"),new InputOutputColumnPair(@"Rooms", @"Rooms"),new InputOutputColumnPair(@"District", @"District"),new InputOutputColumnPair(@"PricePerMeter", @"PricePerMeter")})      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"Area",@"Age",@"Rooms",@"District",@"PricePerMeter"}))      
                                    .Append(mlContext.Transforms.NormalizeMinMax(@"Features", @"Features"))      
                                    .Append(mlContext.Regression.Trainers.FastTreeTweedie(new FastTreeTweedieTrainer.Options(){NumberOfLeaves=4,MinimumExampleCountPerLeaf=15,NumberOfTrees=19,MaximumBinCountPerFeature=211,FeatureFraction=0.352652245444932,LearningRate=0.999999776672986,LabelColumnName=@"Price",FeatureColumnName=@"Features"}));

            return pipeline;
        }
    }
}
