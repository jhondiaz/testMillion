using TestMillion.DTOs;

namespace TestMillion.UseCasesPorts.LogInPorts
{
    public interface IGetLogInOutputPort
    {
        Task Handle(UserDTO userDTO);
    }
}
