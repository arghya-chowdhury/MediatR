using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Examples.PublishStrategies
{
    public class SyncContinueOnException : IPublishStrategy
    {
        public async Task Publish(IEnumerable<Func<INotification, CancellationToken, Task>> handlers, INotification notification, CancellationToken cancellationToken)
        {
            var exceptions = new List<Exception>();

            foreach (var handler in handlers)
            {
                try
                {
                    await handler(notification, cancellationToken).ConfigureAwait(false);
                }
                catch (AggregateException ex)
                {
                    exceptions.AddRange(ex.Flatten().InnerExceptions);
                }
                catch (Exception ex) when (!(ex is OutOfMemoryException || ex is StackOverflowException))
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
