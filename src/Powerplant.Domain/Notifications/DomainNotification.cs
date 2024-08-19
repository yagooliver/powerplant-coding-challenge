using MediatR;

namespace Powerplant.Domain.Notifications
{
    public class DomainNotification(string key, string value) : IRequest<bool>, INotification
    {
        public DateTime DateAndTime { get; private set; } = DateTime.Now;
        public string Key { get; } = key;
        public string Value { get; } = value;
    }
}
