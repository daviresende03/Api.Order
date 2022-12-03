using Order.Application.DataContract.Request.User;
using Order.Application.DataContract.Response.User;
using Order.Domain.Validations.Base;

namespace Order.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<Response<AuthResponse>> AuthAsync(AuthRequest authRequest);
        Task<Response> CreateAsync(CreateUserRequest userRequest);
        Task<Response<List<UserResponse>>> ListByFilterAsync(int userId = 0, string name = null);
    }
}
