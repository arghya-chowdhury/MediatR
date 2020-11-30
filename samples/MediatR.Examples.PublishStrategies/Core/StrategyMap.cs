using System;

namespace MediatR.Examples.PublishStrategies
{
    internal class BaseStrategyMap : PublishStrategy
    {
        protected internal BaseStrategyMap(int value, string displayName) : base(value, displayName)
        {
        }

        protected internal IPublishStrategy Map { get; set; }
    }

    internal class StrategyMap<T> : BaseStrategyMap where T : class, IPublishStrategy
    {
        internal StrategyMap(int value) : base(value, typeof(T).Name)
        {
            Map = Activator.CreateInstance<T>();
        }
    }
}
