namespace MediatR.Examples.PublishStrategies
{
    /// <summary>
    /// Strategy to use when publishing notifications
    /// </summary>
    public class PublishStrategy : Enumeration
    {
        public static readonly PublishStrategy SyncContinueOnException = new StrategyMap<SyncContinueOnException>(0);
        public static readonly PublishStrategy SyncStopOnException = new StrategyMap<SyncStopOnException>(1);
        public static readonly PublishStrategy AsyncContinueOnException = new StrategyMap<AsyncContinueOnException>(2);
        public static readonly PublishStrategy ParallelNoWait = new StrategyMap<ParallelNoWait>(3);
        public static readonly PublishStrategy ParallelWhenAll = new StrategyMap<ParallelWhenAll>(4);
        public static readonly PublishStrategy ParallelWhenAny = new StrategyMap<ParallelWhenAny>(5);

        public PublishStrategy() { }

        public PublishStrategy(int value, string displayName) : base(value, displayName) { }
    }
}
