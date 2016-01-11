using System;
using Brandscreen.Entities;

namespace Brandscreen.Core.Services.Strategies
{
    public class StrategyUpdateOptions
    {
        public AdGroup NewStrategy { get; set; }
        public Guid UserId { get; set; }
    }
}