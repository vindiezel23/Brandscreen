using Castle.Components.DictionaryAdapter;

namespace Brandscreen.Core.Settings
{
    [KeyPrefix("Security.")]
    public interface ISecuritySettings
    {
        string LoginPath { get; }
        string TokenEndpointPath { get; }
        string PublicClientId { get; }

        string Issuer { get; }
        string AudienceId { get; }
        string AudienceSecret { get; }
    }
}