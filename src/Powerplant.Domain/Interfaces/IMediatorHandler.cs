using Powerplant.Domain.Commands;


namespace Powerplant.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task RaiseEvent<T>(T @event) where T : class;
        Task<TResult> Send<TResult>(CommandBase<TResult> command);
    }
}
