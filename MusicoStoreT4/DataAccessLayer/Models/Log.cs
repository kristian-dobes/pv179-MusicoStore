using DataAccessLayer.Models.Enums;

namespace DataAccessLayer.Models
{
    public class Log : BaseEntity
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public RequestSource Source { get; set; }
    }
}
