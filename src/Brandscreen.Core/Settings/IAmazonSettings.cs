using Castle.Components.DictionaryAdapter;

namespace Brandscreen.Core.Settings
{
    [KeyPrefix("Amazon.")]
    public interface IAmazonSettings
    {
        string AccessKey { get; }
        string SecretKey { get; }
        string BucketCreative { get; }
        string BucketCreativeUrl { get; }
    }
}