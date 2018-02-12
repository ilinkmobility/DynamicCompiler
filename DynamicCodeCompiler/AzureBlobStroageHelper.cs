using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        /// <summary>
        /// Contstructor.
        /// </summary>
        private AzureBlobStroageHelper()
        {
            try
            {
                cloudBlobClient = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=blobstoragesample111;"
                + "AccountKey=").CreateCloudBlobClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);

            }
        }

        /// <summary>
        /// Upload file to azure.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileContent"></param>
        public void UploadFile(string fileName, string fileContent)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// upload file confirmation message.
        /// </summary>
        /// <param name="result"></param>
        private void OnUploadCompleted(IAsyncResult result)
        {
            try
            {
                CloudBlockBlob blob = (CloudBlockBlob)result.AsyncState;
                blob.SetMetadata();
                blob.EndUploadFromStream(result);

                MessageBox.Show("Uploaded");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }


        /// <summary>
        /// Download file from azure.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string DownloadFile(string fileName)
        {
            try
            {
                // Get Blob Container
                CloudBlobContainer container = cloudBlobClient.GetContainerReference("documents");
                container.CreateIfNotExist();

                // Get reference to blob (binary content)
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

                // Read content
                using (MemoryStream ms = new MemoryStream())
                {
                    blockBlob.DownloadToStream(ms);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
                return null;
            }
        }

        /// <summary>
        /// Gets the list of files from azure.
        /// </summary>
        /// <returns></returns>
        public List<string> GetListOfFiles()
        {
            try
            {
                var listOfFileNames = new List<string>();
                // Get Blob Container
                CloudBlobContainer container = cloudBlobClient.GetContainerReference("documents");
                container.CreateIfNotExist();

                var blobs = container.ListBlobs();                

                foreach (var blob in blobs)
                {
                    var blobFileName = blob.Uri.Segments.Last();
                    listOfFileNames.Add(blobFileName);
                }  

                return listOfFileNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
                return null;
            }
        }
    }
}
