using MediatR;

namespace Powerplant.Domain.Commands
{
    public abstract class CommandBase<T> : IRequest<T>
    {
        public abstract Dictionary<string, string> GetErrors();
    }
}
