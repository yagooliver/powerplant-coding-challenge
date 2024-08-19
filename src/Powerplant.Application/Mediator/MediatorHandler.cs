using MediatR;
using Powerplant.Domain.Commands;
using Powerplant.Domain.Interfaces;

namespace Powerplant.Application.Mediator
{
    public class MediatorHandler(IMediator mediator) : IMediatorHandler
    {
        private readonly IMediator mediator = mediator;

        public Task RaiseEvent<T>(T @event) where T : class
        {
            return mediator.Publish(@event);
        }

        public async Task<TResult> Send<TResult>(CommandBase<TResult> command)
        {
            return await mediator.Send(command);
        }
    }
}
