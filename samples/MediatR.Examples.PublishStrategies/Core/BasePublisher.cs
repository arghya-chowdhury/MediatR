using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Examples.PublishStrategies
{
    public class BasePublisher : Mediator
    {
        private Func<IEnumerable<Func<INotification, CancellationToken, Task>>, INotification, CancellationToken, Task> _publish;

        protected internal BasePublisher(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        protected internal Task PublishBase<TNotification>(TNotification notification, PublishStrategy strategy, CancellationToken cancellationToken)
        {
            _publish = (strategy as BaseStrategyMap).Map.Publish;
            return Publish(notification, cancellationToken);
        }

        protected override Task PublishCore(IEnumerable<Func<INotification, CancellationToken, Task>> allHandlers, INotification notification, CancellationToken cancellationToken)
            => _publish(allHandlers, notification, cancellationToken);
    }
}
