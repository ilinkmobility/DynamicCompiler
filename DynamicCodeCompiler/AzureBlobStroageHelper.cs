using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCodeCompiler
{
    public class AzureBlobStroageHelper
    {
        private static AzureBlobStroageHelper instance;

        private CloudBlobClient cloudBlobClient;

        public static AzureBlobStroageHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureBlobStroageHelper();
                }
                return instance;
            }
        }

        private AzureBlobStroageHelper()
        {
            cloudBlobClient = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=blobstoragesample111;"
                 + "AccountKey=").CreateCloudBlobClient();
        }

        public void UploadFile(string fileName, string fileContent)
        {
            // Get Blob Container
            CloudBlobContainer container = cloudBlobClient.GetContainerReference("documents");
            container.CreateIfNotExist();

            // Get reference to blob (binary content)
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            // set its properties
            blockBlob.Properties.ContentType = "text/plain";
            blockBlob.Metadata["filename"] = fileName;
            blockBlob.Metadata["filemime"] = "text/plain";

            // Get stream from file bytes
            Stream stream = new MemoryStream(Encoding.ASCII.GetBytes(fileContent));

            // Async upload of stream to Storage
            AsyncCallback UploadCompleted = new AsyncCallback(OnUploadCompleted);
            blockBlob.BeginUploadFromStream(stream, UploadCompleted, blockBlob);
        }

        private void OnUploadCompleted(IAsyncResult result)
        {
            CloudBlockBlob blob = (CloudBlockBlob)result.AsyncState;
            blob.SetMetadata();
            blob.EndUploadFromStream(result);

            System.Windows.Forms.MessageBox.Show("Uploaded");
        }

        public string DownloadFile(string fileName)
        {
            // Get Blob Container
            CloudBlobContainer container = cloudBlobClient.GetContainerReference("documents");
            container.CreateIfNotExist();

            // Get reference to blob (binary content)
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            // Read content
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    blockBlob.DownloadToStream(ms);

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public List<string> GetListOfFiles()
        {
            // Get Blob Container
            CloudBlobContainer container = cloudBlobClient.GetContainerReference("documents");
            container.CreateIfNotExist();

            var blobs = container.ListBlobs();
            
            var listOfFileNames = new List<string>();

            foreach (var blob in blobs)
            {
                var blobFileName = blob.Uri.Segments.Last();
                listOfFileNames.Add(blobFileName);
            }

            return listOfFileNames;
        }
    }
}
