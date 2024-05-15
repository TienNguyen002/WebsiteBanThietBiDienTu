using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using TitanWeb.Application.Media;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class CloudinaryService : ICloundinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudConfiguration> config)
        {
            _cloudinary = new Cloudinary(new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret));
        }

        /// <summary>
        /// Upload Image To Clound
        /// </summary>
        /// <param name="imageStream">The image stream to be uploaded</param>
        /// <param name="fileName">The name of the image file</param>
        /// <returns>The URL of the uploaded image</returns>
        public async Task<string> UploadImageAsync(Stream imageStream, string fileName, string folder)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, imageStream),
            };
            uploadParams.Folder = folder;
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult.Url.ToString();
        }
    }
}
