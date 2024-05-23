namespace Domain.Interfaces.Services
{
    public interface ICloundinaryService
    {
        Task<string> UploadImageAsync(Stream imageStream, string fileName, string folder);
    }
}
