using Emojify;
using Emojify.Configuration;
using Emojify.Predictor;

var successPhrase = "Successfully run the predictor!";
var failPhrase = "Error! The predictor failed to run";
var warningPhrase = "Warning! The predictor is not running";
var unknownPhrase = "Some phrases are impossible to associate with an emoji.";

// Initialize the predictor with a custom configuration
var config = new EmojifyConfiguration
{
    ConfidenceThreshold = PredictionMode.Creative,
    Padding = new PaddingSettings { Left = 1 },
    Position = OutputPosition.Suffix
};

var predictor = new EmojiPredictor(config);

// Predict emojis for the success phrase..
var emoji = predictor.PredictEmoji(successPhrase);

// Print the phrases with emojis and without emojis
Console.WriteLine($"{successPhrase} {emoji}");
Console.WriteLine(failPhrase);
Console.WriteLine(warningPhrase);

// ..or, initialize the Service for Automatic Formatting based on the configuration
EmojifyService.Initialize(config).ApplyGloballyToConsole();

// Print all phrases with emojis
Console.WriteLine(successPhrase);
Console.WriteLine(failPhrase);
Console.WriteLine(warningPhrase);
Console.WriteLine(unknownPhrase);

