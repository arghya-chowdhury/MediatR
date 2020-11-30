using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Examples.PublishStrategies
{
    public class Publisher : BasePublisher
    {
        public Publisher(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        public PublishStrategy DefaultStrategy { get; set; } = PublishStrategy.SyncContinueOnException;

        public Task Publish<TNotification>(TNotification notification)
        {
            return Publish(notification, DefaultStrategy, default);
        }

        public Task Publish<TNotification>(TNotification notification, PublishStrategy strategy)
        {
            return Publish(notification, strategy, default);
        }

        public Task Publish<TNotification>(TNotification notification, PublishStrategy strategy, CancellationToken cancellationToken)
        {
            return PublishBase(notification, strategy, cancellationToken);
        }
    }
}
