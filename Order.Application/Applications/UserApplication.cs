using AutoMapper;
using Order.Application.DataContract.Request.User;
using Order.Application.DataContract.Response.User;
using Order.Application.Interfaces;
using Order.Domain.Interfaces.Services;
using Order.Domain.Models;
using Order.Domain.Validations.Base;

namespace Order.Application.Applications
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;

        public UserApplication(IUserService userService, IMapper mapper, ISecurityService securityService)
        {
            _userService = userService;
            _mapper = mapper;
            _securityService = securityService;
        }

        public Task<Response<AuthResponse>> AuthAsync(AuthRequest authRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> CreateAsync(CreateUserRequest userRequest)
        {
            try
            {
                var isEquals = await _securityService.ComparePassword(userRequest.Password, userRequest.ConfirmPassword);
                if (!isEquals.Data)
                    return Response.Unprocessable(Report.Create("Passwords do not match"));
                userRequest.Password = (await _securityService.EncryptPassword(userRequest.Password)).Data;

                var userModel = _mapper.Map<UserModel>(userRequest);

                return await _userService.CreateAsync(userModel);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Response<List<UserResponse>>> ListByFilterAsync(int userId = 0, string name = null)
        {
            throw new NotImplementedException();
        }
    }
}
