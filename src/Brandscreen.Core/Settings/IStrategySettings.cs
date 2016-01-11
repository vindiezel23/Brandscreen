using Castle.Components.DictionaryAdapter;

namespace Brandscreen.Core.Settings
{
    [KeyPrefix("Strategy.")]
    public interface IStrategySettings
    {
        string RegexBrandSafetyBypassingAccounts { get; }
        double BrandSafetyLevelForBypassingAccounts { get; }
    }
}