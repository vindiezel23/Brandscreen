using System.Collections.Generic;

namespace Brandscreen.Core.Tokens {
    public class TokenDescriptor {
        public string Target { get; set; }
        public string Token { get; set; }
        public string ChainTarget { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class TokenTypeDescriptor {
        public string Target { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TokenDescriptor> Tokens { get; set; }
    }
}