using AutoMapper;
using Order.Application.DataContract.Request.User;
using Order.Application.DataContract.Response.User;
using Order.Application.Interfaces;
using Order.Domain.Interfaces.Services;
using Order.Domain.Validations.Base;

namespace Order.Application.Applications
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserApplication(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public Task<Response<AuthResponse>> AuthAsync(AuthRequest authRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Response> CreateAsync(CreateUserRequest userRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<UserResponse>>> ListByFilterAsync(int userId = 0, string name = null)
        {
            throw new NotImplementedException();
        }
    }
}
