using DataAccessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Log : BaseEntity
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public RequestSource Source { get; set; }
    }
}
