using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Negacom
{
    public class UploadFİle
    {
        private readonly IWebHostEnvironment _webhosteniroment;
        public UploadFİle(IWebHostEnvironment webHostEnvironment)
        {
            _webhosteniroment = webHostEnvironment;
        }
        public string upload(IFormFile file)
        {
            if (file == null)
            {
                return "";
            }
            var path = _webhosteniroment.WebRootPath + "\\image\\Pack\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;
        }
    }
}
