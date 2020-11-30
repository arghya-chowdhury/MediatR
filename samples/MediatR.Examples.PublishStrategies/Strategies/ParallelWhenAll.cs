using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Examples.PublishStrategies
{
    public class ParallelWhenAll : IPublishStrategy
    {
        public Task Publish(IEnumerable<Func<INotification, CancellationToken, Task>> handlers, INotification notification, CancellationToken cancellationToken)
        {
            var tasks = new List<Task>();

            foreach (var handler in handlers)
            {
                tasks.Add(Task.Run(() => handler(notification, cancellationToken)));
            }

            return Task.WhenAll(tasks);
        }
    }
}
