using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Examples.PublishStrategies
{
    public class SyncStopOnException : IPublishStrategy
    {
        public async Task Publish(IEnumerable<Func<INotification, CancellationToken, Task>> handlers, INotification notification, CancellationToken cancellationToken)
        {
            foreach (var handler in handlers)
            {
                await handler(notification, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
