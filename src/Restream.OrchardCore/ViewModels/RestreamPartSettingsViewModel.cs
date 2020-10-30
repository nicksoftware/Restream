using Microsoft.AspNetCore.Mvc.ModelBinding;
using Restream.OrchardCore.Settings;

namespace Restream.OrchardCore.ViewModels
{
    public class RestreamPartSettingsViewModel
    {

        public bool UseSettingsToken { get; set; }
        public string Token { get; set; }

        [BindNever]
        public RestreamPartSettings RestreamPartSettings { get; set; }
    }
}