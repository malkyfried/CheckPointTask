using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointTask
{
    internal class S3Operations
    {
        private static readonly string bucketName = "word-count-storage";
        private static readonly RegionEndpoint region = RegionEndpoint.USEast2;

        public static async Task UploadToS3Async(string keyName, Dictionary<string, int> wordCount)
        {
            string json = JsonConvert.SerializeObject(wordCount);

            using IAmazonS3 client = new AmazonS3Client(region);

            try
            {
                // Check if the key already exists
                bool keyExists = await KeyExistsAsync(client, bucketName, keyName);

                if (keyExists)
                {
                    Console.WriteLine($"Key '{keyName}' already exists in S3 bucket '{bucketName}'.");
                    return;
                }

                var request = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    ContentBody = json
                };

                await client.PutObjectAsync(request);
                Console.WriteLine($"Word count results uploaded to S3 bucket '{bucketName}' with key '{keyName}'.");
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error uploading to S3: {ex.Message}");
            }
            catch (AmazonServiceException ex)
            {
                Console.WriteLine($"Error uploading to S3: {ex.Message}");
            }
        }

        private static async Task<bool> KeyExistsAsync(IAmazonS3 client, string bucketName, string keyName)
        {
            try
            {
                var metadata = await client.GetObjectMetadataAsync(bucketName, keyName);
                return true; // Key exists
            }
            catch (AmazonS3Exception ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return false; // Key doesn't exist
            }
        }

        public static async Task DownloadFromS3Async(string fileName)
        {
            string keyName = fileName;

            using IAmazonS3 client = new AmazonS3Client(region);
            var request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = keyName
            };

            try
            {
                using GetObjectResponse response = await client.GetObjectAsync(request);
                using Stream responseStream = response.ResponseStream;
                using StreamReader reader = new StreamReader(responseStream);
                string content = await reader.ReadToEndAsync();
                Console.WriteLine($"Word count for file '{fileName}':");
                Console.WriteLine(content);
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error downloading from S3: {ex.Message}");
            }
            catch (AmazonServiceException ex)
            {
                Console.WriteLine($"Error downloading from S3: {ex.Message}");
            }
        }
    }
}
