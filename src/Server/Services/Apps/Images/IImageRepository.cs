using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Images
{
    public interface IImageRepository
    {
        //Lấy ảnh bằng Id
        Task<Image> GetImageByIdAsync(int id, CancellationToken cancellationToken = default);

        //Xóa ảnh
        Task<bool> DeleteImage(int id, CancellationToken cancellationToken = default);
    }
}
