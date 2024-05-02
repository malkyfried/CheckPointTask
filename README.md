# CheckPointTask - Word count system
 
This program implements a word count functionality that analyzes a text file,

calculates word frequencies, and uploads the results to an Amazon S3 bucket. 

It can also retrieve and display word counts from existing data in S3.

## Features:

Analyzes text files for word frequencies.

Uploads word count data in JSON format to an S3 bucket.

Retrieves word count data for a specific file from S3 bucket.

## Requirements:

AWS credentials with S3 access are required.

### Usage

**CountWords Class**: Contains functionality to count the occurrences of each word in a specified text file.
**S3Operations Class**: Handles the interaction with Amazon S3 for uploading and downloading word count results.

## Technologies Used:

**Console application:** The project is built using console application.

**C#:** Backend logic and business logic are implemented in C#.

**Visual Studio:** The project is developed using Visual Studio IDE.
