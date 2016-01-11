using Brandscreen.Framework.Events;

namespace Brandscreen.Core.Tokens {
    public interface ITokenProvider : IEventHandler {
        void Describe(DescribeContext context);
        void Evaluate(EvaluateContext context);
    }
}