using BusinessLayer.DTOs.Order;

namespace BusinessLayer.DTOs.User
{
    public class UserDetailDto : UserDto
    {
        public IEnumerable<OrderDto>? Orders { get; set; }
    }
}
