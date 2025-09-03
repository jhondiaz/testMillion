using TestMillion.DTOs;
using TestMillion.UseCasesPorts.LogInPorts;


namespace TestMillion.Presenters.LogIn
{
    public class GetLogInPresenter : IGetLogInOutputPort, IPresenter<UserDTO>
    {
        public UserDTO Content { get; private set; }

        public Task Handle(UserDTO userDTO)
        {
            Content = userDTO;
            return Task.CompletedTask;
        }
    }
}
