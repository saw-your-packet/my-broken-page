using MyBrokenPage.Models;
using System.IO;

namespace MyBrokenPage.Bll.Contracts
{
    public interface IFileUploadHelper
    {
        bool IsExtensionAllowed(CheckExtensionMethodEnum checkExtensionMethodEnum, Stream stream, string filename);

        void SaveImage(Stream stream, string fullPath);
    }
}
