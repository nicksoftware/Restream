using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Restream.OrchardCore.Settings
{
    public class RestreamPartSettingsViewModel
    {

        public bool UseSettingsToken { get; set; }
        public string Token { get; set; }

        [BindNever]
        public RestreamPartSettings RestreamPartSettings { get; set; }
    }
}