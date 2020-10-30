using System;
using System.Threading.Tasks;
using OrchardCore.DisplayManagement.Entities;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Environment.Shell;
using Restream.OrchardCore.ViewModels;
using OrchardCore.Settings;
using Restream.OrchardCore.Settings;

namespace Restream.OrchardCore.Drivers
{
    public class RestreamSettingsDisplayDriver : SectionDisplayDriver<ISite, RestreamSettings>
    {
        public const string GroupId = "Restream";
        private readonly IShellHost _shellHost;
        private readonly ShellSettings _shellSettings;

        public RestreamSettingsDisplayDriver(IShellHost shellHost, ShellSettings shellSettings)
        {
            _shellHost = shellHost;
            _shellSettings = shellSettings;
        }

        public override IDisplayResult Edit(RestreamSettings section, BuildEditorContext context)
        {
            return Initialize<RestreamSettingsViewModel>("RestreamSettings_Edit", model =>
            {
                model.TokenKey = section.TokenKey;
            })
                .Location("Content")
                .OnGroup(GroupId);
        }

        public override async Task<IDisplayResult> UpdateAsync(RestreamSettings section, BuildEditorContext context)
        {
            if (context.GroupId == GroupId)
            {
                var model = new RestreamSettingsViewModel();

                if (await context.Updater.TryUpdateModelAsync(model, Prefix))
                {
                    section.TokenKey = model.TokenKey?.Trim();

                    // Release the tenant to apply settings.
                    await _shellHost.ReleaseShellContextAsync(_shellSettings);
                }
            }

            return await EditAsync(section, context);
        }
    }

}
