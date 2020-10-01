using System.Linq;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using Restream.OrchardCore.Models;
using Restream.OrchardCore.ViewModels;
using Restream.OrchardCore.Settings;

namespace Restream.OrchardCore.Drivers
{
    public class RestreamPartDisplayDriver : ContentPartDisplayDriver<RestreamPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public RestreamPartDisplayDriver(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public override IDisplayResult Display(RestreamPart restreamPart)
        {
            return Combine(
                Initialize<RestreamPartViewModel>("RestreamPart", m => BuildViewModel(m, restreamPart))
                    .Location("Detail", "Content:20"),
                Initialize<RestreamPartViewModel>("RestreamPart_Summary", m => BuildViewModel(m, restreamPart))
                    .Location("Summary", "Meta:5")
            );
        }

        public override IDisplayResult Edit(RestreamPart RestreamPart)
        {
            return Initialize<RestreamPartViewModel>("RestreamPart_Edit", m => BuildViewModel(m, RestreamPart));
        }

        public override async Task<IDisplayResult> UpdateAsync(RestreamPart model, IUpdateModel updater)
        {
            var settings = GetRestreamPartSettings(model);

            await updater.TryUpdateModelAsync(model, Prefix, t => t.Height);
            await updater.TryUpdateModelAsync(model, Prefix, t => t.Width);

            return Edit(model);
        }


        public RestreamPartSettings GetRestreamPartSettings(RestreamPart part)
        {
            var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition(part.ContentItem.ContentType);
            var contentTypePartDefinition = contentTypeDefinition.Parts.FirstOrDefault(p => p.PartDefinition.Name == nameof(RestreamPart));
            var settings = contentTypePartDefinition.GetSettings<RestreamPartSettings>();

            return settings;
        }

        private void BuildViewModel(RestreamPartViewModel model, RestreamPart part)
        {
            var settings = GetRestreamPartSettings(part);

            model.ContentItem = part.ContentItem;
            model.Token = settings.Token;
            model.Width = part.Width;
            model.Height = part.Height;
            model.RestreamPart = part;
            model.Settings = settings;
        }
    }
}
