namespace MobileApp;

public partial class StartPage : ContentPage
{
	public List<ContentPage> lehed = new List<ContentPage>() { new TextPage(0), new FigurePage(1) };
	public List<string> Tekstid = new List<string> { "Tee lahti TekstPage", "Tee lahti FigurePage" };
	ScrollView sv;
	VerticalStackLayout vst;

	public StartPage()
	{
		Title = "Avaleht";
		vst = new VerticalStackLayout { BackgroundColor = Color.FromRgb(150, 100, 20) };	

		for (int i = 0; i < Tekstid.Count; i++)
		{
			Button btn = new Button
			{
				Text = Tekstid[i],
				BackgroundColor = Color.FromRgb(20,100,200),
				TextColor = Color.FromRgb(10,20,15),
				FontFamily = "Tomorrow-Bold",
				BorderWidth = 10,
				ZIndex = i
			};
			vst.Add(btn);
            btn.Clicked += Btn_Clicked;
		}
		sv = new ScrollView { Content = vst };
		Content = sv;

	}

    private async void Btn_Clicked(object? sender, EventArgs e)
    {
		Button btn = sender as Button;
		await Navigation.PushAsync(lehed[btn.ZIndex]);
    }
}