using System.Collections.Generic;
using Brandscreen.Framework;

namespace Brandscreen.Core.Tokens {
    public interface ITokenManager : IDependency {
        IEnumerable<TokenTypeDescriptor> Describe(IEnumerable<string> targets);
        IDictionary<string, object> Evaluate(string target, IDictionary<string, string> tokens, IDictionary<string, object> data);
    }
}