namespace SecureStorageIssue;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		var key = "TestKey";
        // After restarting the app and pressing the button again we expect readOldKey to be filled
		// because we called SetAsync after the RemoveAll(), readOldKey will be null though.
        var readOldKey = await SecureStorage.Default.GetAsync(key); 
		SecureStorage.RemoveAll();
		await SecureStorage.Default.SetAsync(key, "Testvalue");
		var readNewKey = await SecureStorage.Default.GetAsync(key);
	}
}
