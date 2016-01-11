using System.Collections.Generic;

namespace Brandscreen.Core.Tokens {
    public abstract class DescribeContext {
        public abstract IEnumerable<TokenTypeDescriptor> Describe(params string[] targets);
        public abstract DescribeFor For(string target);
        public abstract DescribeFor For(string target, string name, string description);
    }
}