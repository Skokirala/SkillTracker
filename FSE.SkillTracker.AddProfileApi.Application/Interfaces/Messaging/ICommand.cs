using MediatR;

namespace FSE.SkillTracker.AddProfileApi.Application.Interfaces.Messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
