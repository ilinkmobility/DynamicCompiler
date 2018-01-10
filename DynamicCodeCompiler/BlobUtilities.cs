using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCodeCompiler
{
    internal class BlobUtilities
    {
        public static CloudBlobClient GetBlobClient
        {
            get
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=blobstoragesample111;"
                 + "AccountKey=+J6Dpm1Wjkfghn0tQcjK4DImh78qnDEr4EcF+R16rhmSmTF+8fHo8UrABMEyLwlYkJ3j3qBd1vr/iuPfHHPyhQ==");
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                return blobClient;
            }
        }
    }
}
