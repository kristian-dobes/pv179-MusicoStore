using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class ImageDto
    {
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public byte[] FileContents { get; set; }
    }
}
