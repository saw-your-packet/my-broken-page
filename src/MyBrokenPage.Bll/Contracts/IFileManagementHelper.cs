using MyBrokenPage.Models;
using System.IO;

namespace MyBrokenPage.Bll.Contracts
{
    public interface IFileManagementHelper
    {
        bool IsExtensionAllowed(CheckExtensionMethodEnum checkExtensionMethodEnum, Stream stream, string filename);

        void SaveImage(Stream stream, string fullPath);

        byte[] DownloadImage(string fullPath);

        void UploadZip(string basePath, Stream zipStream);
    }
}
