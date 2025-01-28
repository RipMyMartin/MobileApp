namespace MobileApp;

public partial class TextPage : ContentPage
{
	Label lbl;
	Editor editor;
	HorizontalStackLayout hsl;
	List<string> buttons = new List<string> { "Tagasi", "Avaleht","Edasi" };
	public TextPage(int k)
	{
		lbl = new Label
		{
			Text = "Pealkiri",
			TextColor = Color.FromRgb(100, 10, 10),
			FontFamily = "Tomorrow-Bold",
			FontAttributes = FontAttributes.Bold,
			TextDecorations = TextDecorations.Underline,
			HorizontalTextAlignment = TextAlignment.Center,
			VerticalTextAlignment = TextAlignment.Center,
			FontSize = 28,
		};
		editor = new Editor
		{
			Placeholder = "Vihje: Sisesta siia tekst",
			PlaceholderColor = Color.FromRgb(250, 200, 100),
			TextColor = Color.FromRgb(200, 200, 100),
			BackgroundColor = Color.FromRgb(100, 50, 200),
			FontSize = 28,
			FontAttributes = FontAttributes.Italic,
		};
        editor.TextChanged += Editor_TextChanged;
		hsl = new HorizontalStackLayout { };
		for (int i = 0; i < buttons.Count; i++)
		{
			Button b = new Button
			{
				Text = buttons[i],
				ZIndex = i,
				WidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width / 8.3
			};
			hsl.Add(b);
            b.Clicked += B_Clicked;
		}
		VerticalStackLayout vsl = new VerticalStackLayout
		{
			Children = { lbl, editor, hsl },
			VerticalOptions = LayoutOptions.End,
		};
		Content = vsl;
	}

    private void B_Clicked(object? sender, EventArgs e)
    {
        lbl.Text=editor.Text;
    }

	private async void Editor_TextChanged(object? sender, TextChangedEventArgs e)
	{
		Button btn = (Button)sender;
		if (btn.ZIndex == 0)
		{
			await Navigation.PushAsync(new TextPage(btn.ZIndex));
		}
		else if (btn.ZIndex == 1)
		{
			await Navigation.PushAsync(new StartPage());
		}
		else
		{
			await Navigation.PushAsync(new FigurePage(btn.ZIndex));
		}
	}
}