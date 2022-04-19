using MediatR;

namespace FSE.SkillTracker.AddProfileApi.Application.Interfaces.Messaging
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}
