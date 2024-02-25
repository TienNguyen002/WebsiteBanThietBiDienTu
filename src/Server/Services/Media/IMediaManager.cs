using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Media
{
    public interface IMediaManager
    {
        Task<string> SaveFileAsync(
            Stream buffer,
            string originalFileName,
            string contentType,
            CancellationToken cancellationToken = default);
        Task<string> SaveImgFileAsync(
            Stream buffer,
            string originalFileName,
            string contentType,
            CancellationToken cancellationToken = default);
        Task<bool> DeleteFileAsync(
            string filePath,
            CancellationToken cancellationToken = default);
    }
}
