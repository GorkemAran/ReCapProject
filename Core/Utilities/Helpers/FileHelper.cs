using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var result = NewPath(file);

            var sourcePath = Path.GetTempFileName();

            using (var upload = new FileStream(sourcePath, FileMode.Create))
            {
                file.CopyTo(upload);
            }

            File.Move(sourcePath, Environment.CurrentDirectory + @"\wwwroot" + result);
            return result;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = NewPath(file).ToString();
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string NewPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName.Trim());
            string fileExtension = fileInfo.Extension;
            string path = @"\uploads";
            var newPath = Guid.NewGuid().ToString() + fileExtension;
            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
