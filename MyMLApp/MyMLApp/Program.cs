// See https://aka.ms/new-console-template for more information
using MyMLApp;

Console.WriteLine("Hello, World!");
//Load sample data
var sampleData = new SentimentModel.ModelInput()
{
    Col0 = @"Crust is not good.",
};

//Load model and predict output
var result = SentimentModel.Predict(sampleData);

// If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
var sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";
Console.WriteLine($"Text: {sampleData.Col0}\nSentiment: {sentiment}");
