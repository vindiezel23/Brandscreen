using System.Collections.Generic;

namespace Brandscreen.Core.Tokens {
    public abstract class DescribeFor {
        public abstract IEnumerable<TokenDescriptor> Tokens { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract DescribeFor Token(string token, string name, string description);
        public abstract DescribeFor Token(string token, string name, string description, string chainTarget);
    }
}