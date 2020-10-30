using System.Linq;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using Restream.OrchardCore.Models;
using Restream.OrchardCore.ViewModels;
using Restream.OrchardCore.Settings;
using OrchardCore.Settings;
using OrchardCore.Entities;

namespace Restream.OrchardCore.Drivers
{
    public class RestreamPartDisplayDriver : ContentPartDisplayDriver<RestreamPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly ISiteService _siteService;

        public RestreamPartDisplayDriver(IContentDefinitionManager contentDefinitionManager, ISiteService siteService  )
        {
            _contentDefinitionManager = contentDefinitionManager;
            _siteService = siteService;
        }

        public override IDisplayResult Display(RestreamPart restreamPart)
        {
            return Combine(
                Initialize<RestreamPartViewModel>("RestreamPart",async m  =>
                {
                  await  BuildViewModel(m, restreamPart);
                 
                })
                .Location("Detail", "Content:20"),
                Initialize<RestreamPartViewModel>("RestreamPart_Summary",async m => await BuildViewModel(m, restreamPart))
                    .Location("Summary", "Meta:5")
            );
        }

        public override IDisplayResult Edit(RestreamPart RestreamPart)
        {
            return Initialize<RestreamPartViewModel>("RestreamPart_Edit", async m =>await BuildViewModel(m, RestreamPart));
        }

        public override async Task<IDisplayResult> UpdateAsync(RestreamPart model, IUpdateModel updater)
        {
            var settings = GetRestreamPartSettings(model);


            await updater.TryUpdateModelAsync(model, Prefix, t => t.Width);
            await updater.TryUpdateModelAsync(model, Prefix, t => t.Height);

            return Edit(model);
        }


        public RestreamPartSettings GetRestreamPartSettings(RestreamPart part)
        {
            var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition(part.ContentItem.ContentType);
            var contentTypePartDefinition = contentTypeDefinition.Parts.FirstOrDefault(p => p.PartDefinition.Name == nameof(RestreamPart));
            var settings = contentTypePartDefinition.GetSettings<RestreamPartSettings>();

            return settings;
        }

        private async Task BuildViewModel(RestreamPartViewModel model, RestreamPart part)
        {
            var siteSettings = await _siteService.GetSiteSettingsAsync();
            var partsettings = GetRestreamPartSettings(part);
            var settings = siteSettings.As<RestreamSettings>();
            model.ContentItem = part.ContentItem;
            
            model.Token = settings.TokenKey;
            model.Width = part.Width;
            model.Height = part.Height;
            model.RestreamPart = part;
            model.Settings = partsettings;
        }
    }
}
