# Word Count system
 
This console application is written in C# and is designed to count the occurrences of each word in a given text file,

upload the results to an Amazon S3 bucket, and then download the results from the S3 bucket.

## Prerequisites

Before running the program, ensure you have the following:

- .NET Core SDK installed on your machine.
- AWS account credentials configured with access to the desired S3 bucket.

## Installation

1. Clone or download this repository to your local machine.

    git clone https://github.com/your-repo/word-count-console-app.git

2. Open the solution file in Visual Studio or your preferred C# IDE.

43. Build the solution to restore packages and compile the project.

## Usage`

1. Run the program. The word count results will be calculated for the specified file, and then uploaded to the configured S3 bucket.

2. After the upload is successful, the program will automatically download the word count results from the S3 bucket and display them in the console.

## Configuration

- Ensure you have an AWS S3 bucket set up. Update the `bucketName` and `region` variables in the `S3Operations.cs` file with your bucket's details.

