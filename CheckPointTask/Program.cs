using CheckPointTask;

string pathToDataFolder = "../../../Data/";
string fileName = "InputText2.txt";

// Count amount of each word in specific file
Dictionary<string, int> wordCount= CountWords.Count(pathToDataFolder + fileName);

// Store the results in S3 bucket
//await S3Operations.UploadToS3Async(fileName, wordCount);

// Reading results from the S3 bucket
await S3Operations.DownloadFromS3Async(fileName);



