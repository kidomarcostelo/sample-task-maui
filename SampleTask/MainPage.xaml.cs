using System.Windows.Input;

namespace SampleTask;

public partial class MainPage : ContentPage
{
    public bool SecondButtonEnabled { get; set; }

    public ICommand IncrementCounterCommand { get; set; }

    private int _counter;
    public int Counter
    {
        get { return _counter; }
        set
        {
            if (_counter != value)
            {
                _counter = value;
                OnPropertyChanged(nameof(Counter));
            }
        }
    }

    public MainPage()
	{
		InitializeComponent();
        SecondButtonEnabled = true;
        IncrementCounterCommand = new Command(IncrementCounter, CanIncrementCounter);
        BindingContext = this;
    }

    private void FirstBtn_Clicked(object sender, EventArgs e)
    {
        SecondButtonEnabled = !SecondButtonEnabled;
        ((Command)IncrementCounterCommand).ChangeCanExecute();
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

