using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;
using System.Web;

namespace Pager
{
    public class AzureStorageService : IStorageService
    {
        private CloudBlobContainer _container;

        public AzureStorageService(IConfigurationRoot config)
        {
            // TODO: Replace with GetConnectionString. This is so cool!
            var connectionString = config.GetValue<string>("AzureStorageConnectionString");
            var containerName = config.GetValue<string>("ContainerName");
            var imagesBlobName = config.GetValue<string>("ImagesBlobName");

            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var client = storageAccount.CreateCloudBlobClient();
            _container = client.GetContainerReference(containerName);
        }

        public Uri UploadStreamAs(Stream stream, string name)
        {
            var safeName = HttpUtility.UrlEncode(name);
            var cloudBlockBlob = _container.GetBlockBlobReference(safeName);

            // Block instead of uploading in the background
            Task.Run(() => cloudBlockBlob.UploadFromStreamAsync(stream));

            return new Uri($"https://pagerassets.blob.core.windows.net/{_container.Name}/{safeName}");
		}
    }
}