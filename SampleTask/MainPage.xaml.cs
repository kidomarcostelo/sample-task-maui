using System.Windows.Input;

namespace SampleTask;

public partial class MainPage : ContentPage
{
    public int Counter { get; set; }
    public bool SecondButtonEnabled { get; set; }

    public ICommand IncrementCounterCommand { get; set; }


    public MainPage()
	{
		InitializeComponent();
        SecondButtonEnabled = true;
        IncrementCounterCommand = new Command(IncrementCounter, CanIncrementCounter);
        BindingContext = this;
    }


	private void OnCounterClicked(object sender, EventArgs e)
	{
        ((Command)IncrementCounterCommand).ChangeCanExecute();

		SecondBtn.Text = $"{Counter}";

		SemanticScreenReader.Announce(SecondBtn.Text);
	}

    private void FirstBtn_Clicked(object sender, EventArgs e)
    {
        SecondButtonEnabled = !SecondButtonEnabled;

		SecondBtn.IsEnabled = CanIncrementCounter();
    }

    void IncrementCounter()
    {
        Counter++;
    }

    bool CanIncrementCounter()
    {
        return SecondButtonEnabled;
    }
}

