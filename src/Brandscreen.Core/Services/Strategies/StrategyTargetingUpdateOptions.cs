using System;
using System.Collections.Generic;

namespace Brandscreen.Core.Services.Strategies
{
    public class StrategyTargetingUpdateOptions<T>
    {
        public StrategyTargetingUpdateOptions()
        {
            Targetings = new List<StrategyTargetingItem<T>>();
        }

        public Guid StrategyUuid { get; set; }

        public IList<StrategyTargetingItem<T>> Targetings { get; set; }
    }

    public class StrategyTargetingItem<T>
    {
        public T Id { get; set; }
        public TargetingActionEnum TargetingAction { get; set; }
    }
}