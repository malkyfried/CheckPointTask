using CheckPointTask;

//Count amount of each word
Dictionary<string, int> wordCount= CountWords.Count("./InputText1.txt");

Console.WriteLine("Word Count Results:");
foreach (var pair in wordCount)
{
    Console.WriteLine($"{pair.Key}: {pair.Value}");
}


string fileName = "InputText1.txt";

// Store the results in S3 bucket
//await S3Operations.UploadToS3Async(fileName, wordCount);

// Reading results from the S3 bucket
await S3Operations.DownloadFromS3Async(fileName);



