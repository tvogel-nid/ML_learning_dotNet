// See https://aka.ms/new-console-template for more information
using WiFi_Indoor_Localization;

Console.WriteLine("Hello, World!");
//Load sample data
var sampleDataRoom1 = new WiFi_IndoorLocalization.ModelInput()
{
    RSSI1 = -68F,
    RSSI2 = -57F,
    RSSI3 = -61F,
    RSSI4 = -65F,
    RSSI5 = -71F,
    RSSI6 = -85F,
    RSSI7 = -85F,
};

var sampleDataRoom4 = new WiFi_IndoorLocalization.ModelInput()
{
    RSSI1 = -52,
    RSSI2 = -52,
    RSSI3 = -56,
    RSSI4 = -62,
    RSSI5 = -52,
    RSSI6 = -92,
    RSSI7 = -85,
};

//Load model and predict output
var result = WiFi_IndoorLocalization.Predict(sampleDataRoom4);
Console.WriteLine($"Result: {result.PredictedLabel}");

