using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;

namespace Brandscreen.Core.Settings
{
    [KeyPrefix("Creative.")]
    public interface ICreativeSettings
    {
        string RegexBeaconUrl { get; }
        string RegexFbxBeaconUrl { get; }
        int MediaSizeDiscrepancy { get; }
        int ThumbnailWidth { get; }
        int ThumbnailHeight { get; }
        int DoohPreviewWidth { get; }
        int DoohPreviewHeight { get; }
        int MaxDoohImageSizeInKb { get; }
        int MaxDoohVideoSizeInKb { get; }

        bool SendingRejectionEmail { get; }

        [StringList]
        IList<string> VastUrlMacroReplacements { get; }
    }
}