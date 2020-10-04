using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using Restream.OrchardCore.Drivers;
using Restream.OrchardCore.Settings;

namespace Restream.OrchardCore
{

    public class AdminMenu : INavigationProvider
    {
        private readonly IStringLocalizer S;

        public AdminMenu(IStringLocalizer<AdminMenu> localizer)
        {
            S = localizer;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder.Add(S["Configuration"], config => config
            .Add(S["Settings"], settings => settings
                .Add(S["Restream"],S["Restream"].PrefixPosition(),set => set
                .Action("Index", "Admin", new { area = "OrchardCore.Settings", groupId = RestreamSettingsDisplayDriver.GroupId })
                .LocalNav()
                )));    

            return Task.CompletedTask;
        }
    }
}