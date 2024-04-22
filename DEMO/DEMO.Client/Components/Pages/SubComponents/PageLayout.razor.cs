using Microsoft.AspNetCore.Components;

namespace DEMO.Client.Components.Pages.SubComponents;

public partial class PageLayout : ComponentBase
{
    [Parameter]
    public string Breadcrumb { get; set; } = string.Empty;

	[Parameter]
    public string Breadcrumbs { get; set; } = string.Empty;

	[Parameter]
    public string PageTitle { get; set; } = string.Empty;

	[Parameter]
    public string PageLink { get; set; } = string.Empty;

	[Parameter]
    public RenderFragment? ChildContent { get; set; }

    public bool IsLoaded { get; set; }

    protected override void OnInitialized()
    {
        IsLoaded = true;
    }
}