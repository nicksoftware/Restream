using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Restream.OrchardCore.Settings
{
    public class RestreamPartSettingsViewModel
    {
        public string Token { get; set; }

        [BindNever]
        public RestreamPartSettings RestreamPartSettings { get; set; }
    }
}