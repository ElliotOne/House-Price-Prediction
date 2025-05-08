using HousePricePrediction_Manual;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;

var mlContext = new MLContext();

// Get the directory where the Program.cs is located
string directoryPath = AppDomain.CurrentDomain.BaseDirectory;

// Navigate up two directories from the bin/Debug/net6.0 folder to the project root directory
string projectRootDirectory = Path.Combine(directoryPath, @"..\..\..");

// Resolve the full path for the project root
projectRootDirectory = Path.GetFullPath(projectRootDirectory);

// Combine it with the dataset file name
string datasetPath = Path.Combine(projectRootDirectory, "dataset.csv");
IDataView dataView = mlContext.Data.LoadFromTextFile<HouseModel>(datasetPath, separatorChar: ',', hasHeader: true);

var pipeline = mlContext.Transforms.ReplaceMissingValues(
            new[]
            {
                new InputOutputColumnPair(@"Area", @"Area"),
                new InputOutputColumnPair(@"Age", @"Age"),
                new InputOutputColumnPair(@"Rooms", @"Rooms"),
                new InputOutputColumnPair(@"District", @"District"),
                new InputOutputColumnPair(@"PricePerMeter", @"PricePerMeter")
            }
        )
        .Append(mlContext.Transforms.Concatenate(@"Features", new[] { @"Area", @"Age", @"Rooms", @"District", @"PricePerMeter" }))
        .Append(mlContext.Transforms.NormalizeMinMax(@"Features", @"Features"))
        .Append(mlContext.Regression.Trainers.FastTreeTweedie(
            new FastTreeTweedieTrainer.Options()
            {
                NumberOfLeaves = 4,
                MinimumExampleCountPerLeaf = 15,
                NumberOfTrees = 19,
                MaximumBinCountPerFeature = 211,
                FeatureFraction = 0.352652245444932,
                LearningRate = 0.999999776672986,
                LabelColumnName = @"Price",
                FeatureColumnName = @"Features"
            })
        );

var testTrainSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
var trainedModel = pipeline.Fit(testTrainSplit.TrainSet);

IDataView transformTestDataVIew = trainedModel.Transform(dataView);

var metrics = mlContext.Regression.Evaluate(transformTestDataVIew, labelColumnName: "Price", scoreColumnName: "Score");

PrintRegressionMetrics("FastTreeTweedie", metrics);


var predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(trainedModel);

var testInputs = mlContext.Data.CreateEnumerable<ModelInput>(testTrainSplit.TestSet, false);

foreach (var input in testInputs)
{
    var predictions = predictionEngine.Predict(input);
    Console.WriteLine($"Predict Price for {predictions.Index} is {predictions.Price:C}");
}

Console.ReadKey();

static void PrintRegressionMetrics(string name, RegressionMetrics metrics)
{
    Console.WriteLine($"*********************************");
    Console.WriteLine($"*Metrics for {name} regression model      ");
    Console.WriteLine($"*-----------------------------------");
    Console.WriteLine($"* LossFn:        {metrics.LossFunction:0.##}");
    Console.WriteLine($"* R2 Score:      {metrics.RSquared:0.##}");
    Console.WriteLine($"* Absolute loss: {metrics.MeanAbsoluteError:#.##}");
    Console.WriteLine($"* Squared loss:  {metrics.MeanSquaredError:#.##}");
    Console.WriteLine($"* RMS loss:      {metrics.RootMeanSquaredError:#.##}");
    Console.WriteLine($"**************************************");
}
