using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Brandscreen.Framework.Settings
{
    [DebuggerStepThrough]
    public class SettingWrapper : NameValueCollection
    {
        public SettingWrapper(NameValueCollection appSettings)
            : base(appSettings)
        {
        }

        public override string Get(string name)
        {
            if (name.EndsWith(".") || name.EndsWith("_"))
            {
                return base.Get(name);
            }

            foreach (var key in AllKeys)
            {
                if (key.StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    var val = base.Get(name);
                    if (!string.IsNullOrEmpty(val))
                    {
                        return val;
                    }
                    break;
                }
            }

            throw new KeyNotFoundException($"{name} - The given key was not present in the dictionary or the value for the key is not set.");
        }
    }
}