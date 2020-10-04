using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;
using Restream.OrchardCore.Settings;
using Restream.OrchardCore.Models;
using System.ComponentModel;

namespace Restream.OrchardCore.ViewModels
{

    public class RestreamPartViewModel
    {


        [DisplayName("Frame width")]
        public int Width { get; set; }
        [DisplayName("Frame Height")]
        public int Height { get; set; }
        public bool UseTokenFromPartSettings { get; set; }
        public bool SettingsAreConfigured { get; set; }
        [BindNever]
        public ContentItem ContentItem { get; set; }

        [BindNever]
        public RestreamPart RestreamPart { get; set; }

        [BindNever]
        public RestreamPartSettings Settings { get; set; }
        public string Token { get;  set; }
    }
}
