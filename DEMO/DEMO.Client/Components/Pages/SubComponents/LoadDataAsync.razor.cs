using Microsoft.AspNetCore.Components;

namespace DEMO.Client.Components.Pages.SubComponents;

public partial class LoadDataAsync : IComponent
{
	[Parameter]
	public Func<Task>? Data { get; set; }

	[Parameter]
	public RenderFragment? BodyContent { get; set; }

	private bool _isLoaded = false;

	protected override async Task OnInitializedAsync()
	{
		await LoadData();
	}

	private async Task LoadData()
	{
		if (Data is not null)
		{
			_isLoaded = true;
		}

		StateHasChanged();
	}
}