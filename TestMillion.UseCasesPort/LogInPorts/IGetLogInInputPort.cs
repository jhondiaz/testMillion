using TestMillion.DTOs;

namespace TestMillion.UseCasesPorts.LogInPorts
{
    public interface IGetLogInInputPort
    {
        Task<Task> Handle(LogInDTO logInDTO);
    }
}
