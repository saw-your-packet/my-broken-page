using FileTypeChecker;
using Ionic.Zip;
using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.Bll.Exceptions;
using MyBrokenPage.Models;
using MyBrokenPage.Models.Constants;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyBrokenPage.Bll.Logic
{
    public class FileManagementHelper : IFileManagementHelper
    {
        public bool IsExtensionAllowed(CheckExtensionMethodEnum checkExtensionMethodEnum, Stream stream, string filename)
        {
            var isExtensionAllowed = false;

            if (stream == null)
            {
                return isExtensionAllowed;
            }

            switch (checkExtensionMethodEnum)
            {
                case CheckExtensionMethodEnum.MagicNumberOwnImplementation:
                    isExtensionAllowed = CheckByOwnImplementation(stream);
                    break;
                case CheckExtensionMethodEnum.ExtensionFromFileName:
                    isExtensionAllowed = CheckByFilename(filename);
                    break;
                case CheckExtensionMethodEnum.FileTypeCheckerNuget:
                    isExtensionAllowed = FileTypeValidator.IsImage(stream);
                    break;
                default:
                    break;
            }

            return isExtensionAllowed;
        }

        public void SaveImage(Stream stream, string fullPath)
        {
            using var writeStream = new FileStream(fullPath, FileMode.Create);

            stream.CopyTo(writeStream);
        }

        public byte[] DownloadImage(string fullPath)
        {
            try
            {
                var file = File.ReadAllBytes(fullPath);

                return file;
            }
            catch (Exception)
            {
                throw new ExceptionResourceNotFound($"File not on disk or can't be accessed: {fullPath}");
            }
        }

        public void UploadZip(string basePath, Stream zipStream)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var zipFile = ZipFile.Read(zipStream);

            if(Directory.Exists(basePath) == false)
            {
                Directory.CreateDirectory(basePath);
            }

            zipFile.ExtractAll(basePath);
        }

        private bool CheckByOwnImplementation(Stream stream)
        {
            var isExtensionAllowed = false;
            var maxBytesToRead = SupportedFileFormats.FileSignatures.Max(fileSignature => fileSignature.Length);
            byte[] buffer = new byte[maxBytesToRead];
            stream.Read(buffer, 0, maxBytesToRead);

            foreach (var fileSignature in SupportedFileFormats.FileSignatures)
            {
                isExtensionAllowed = true;

                for (int i = 0; i < fileSignature.Length; i++)
                {
                    if (fileSignature[i] != buffer[i])
                    {
                        isExtensionAllowed = false;
                        break;
                    }
                }

                if (isExtensionAllowed)
                {
                    break;
                }
            }

            return isExtensionAllowed;
        }

        private bool CheckByFilename(string name)
        {
            var extension = Regex.Match(name, "\\.\\w+$").Groups[0]?.Value;
            var isAllowedFileExtension = SupportedFileFormats.Extensions.Contains(extension, StringComparer.OrdinalIgnoreCase);

            return isAllowedFileExtension;
        }
    }
}
