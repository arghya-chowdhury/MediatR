using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Examples.PublishStrategies
{
    public class ParallelNoWait : IPublishStrategy
    {
        public Task Publish(IEnumerable<Func<INotification, CancellationToken, Task>> handlers, INotification notification, CancellationToken cancellationToken)
        {
            foreach (var handler in handlers)
            {
                Task.Run(() => handler(notification, cancellationToken));
            }

            return Task.CompletedTask;
        }
    }
}
