using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;

namespace AzureBlobStorageProto
{
    public class AzureStorageCRUD
    {
        private CloudBlobClient blobClient;

        public AzureStorageCRUD()
        {
            // Retrieve storage account from connection string.
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);

            // Create the blob client.
            blobClient = storageAccount.CreateCloudBlobClient();
        }

        public CloudBlobContainer GetContainer(string containerName)
        {            
            // Retrieve a reference to a container. 
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();

            return container;
        }

        public CloudBlockBlob UploadFile(CloudBlobContainer container, string blobName, string localFilePath)
        {
            // Retrieve reference to a blob with given blob name
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

            // Create or overwrite the blob with contents from a local file.
            using (var fileStream = System.IO.File.OpenRead(localFilePath))
            {
                blockBlob.UploadFromStream(fileStream);
            }

            return blockBlob;
        }
        
    }
}
