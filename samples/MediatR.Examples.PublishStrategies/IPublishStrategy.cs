using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Examples.PublishStrategies
{
    public interface IPublishStrategy
    {
        public Task Publish(IEnumerable<Func<INotification, CancellationToken, Task>> handlers, INotification notification, CancellationToken cancellationToken);
    }
}
