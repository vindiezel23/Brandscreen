using Castle.Components.DictionaryAdapter;

namespace Brandscreen.Core.Settings
{
    [KeyPrefix("Site.")]
    public interface ISiteSettings
    {
        bool Profiling { get; }
        int ProfilingInterval { get; }

        string QueueEndPoint { get; set; }
    }
}