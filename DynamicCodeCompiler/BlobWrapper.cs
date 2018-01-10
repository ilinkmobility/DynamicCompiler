using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCodeCompiler
{
    public class BlobWrapper
    {
        public async Task<bool> UploadFileToBlob(CustomFile file)
        {
            try
            {
                // Get Blob Container
                CloudBlobContainer container = BlobUtilities.GetBlobClient.GetContainerReference("documents");
                container.CreateIfNotExist();

                // Get reference to blob (binary content)
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);

                // set its properties
                blockBlob.Properties.ContentType = file.FileMime;
                blockBlob.Metadata["filename"] = file.FileName;
                blockBlob.Metadata["filemime"] = file.FileMime;

                // Get stream from file bytes
                Stream stream = new MemoryStream(file.FileBytes);

                // Async upload of stream to Storage
                AsyncCallback UploadCompleted = new AsyncCallback(OnUploadCompleted);
                blockBlob.BeginUploadFromStream(stream, UploadCompleted, blockBlob);
            }
            catch (Exception ex)
            {
                var x = ex;
            }
            

            return true;
        }

        private void OnUploadCompleted(IAsyncResult result)
        {
            CloudBlockBlob blob = (CloudBlockBlob)result.AsyncState;
            blob.SetMetadata();
            blob.EndUploadFromStream(result);
        }

        public async Task<byte[]> DownloadFileFromBlob(string FileName)
        {
            // Get Blob Container
            CloudBlobContainer container = BlobUtilities.GetBlobClient.GetContainerReference("documents");

            // Get reference to blob (binary content)
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(FileName);

            // Read content
            using (MemoryStream ms = new MemoryStream())
            {
                blockBlob.DownloadToStream(ms);

                File.WriteAllBytes(@"C:\Users\aarooraa\Desktop\Test2.cs", ms.ToArray());
                return ms.ToArray();
            }
        }
    }
}
