namespace AnimalMatchingGame
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            AnimalButtons.IsVisible = false;
        }

        private void PlayAgainButton_Clicked(object sender, EventArgs e)
        {
            AnimalButtons.IsVisible = true;
            PlayAgainButton.IsVisible = false;

            List<string> animalEmoji = new List<string>()
            {
                "🐙", "🐙",
                "🐡", "🐡",
                "🐈", "🐈",
                "🐘", "🐘",
                "🐪", "🐪",
                "🦘", "🦘",
                "🐳", "🐳",
                "🦕", "🦕"

            };

            foreach (var button in AnimalButtons.Children.OfType<Button>())
            {
                int index = Random.Shared.Next(animalEmoji.Count);
                string mextEmoji = animalEmoji[index];
                button.Text = mextEmoji;
                animalEmoji.RemoveAt(index);
            }
        }

        Button lastClicked;
        bool findingMatch = false;
        int matchesFound;

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button buttonClicked)
            {
                if (!string.IsNullOrEmpty(buttonClicked.Text) && (findingMatch == false))
                {
                    buttonClicked.BackgroundColor = Colors.Red;
                    lastClicked = buttonClicked;
                    findingMatch = true;
                }
                else
                {
                    if ((buttonClicked != lastClicked) && buttonClicked.Text == lastClicked.Text)
                    {
                        matchesFound++;
                        lastClicked.Text = "";
                        buttonClicked.Text = "";
                    }
                    lastClicked.BackgroundColor = Colors.LightBlue;
                    buttonClicked.BackgroundColor = Colors.LightBlue;
                    findingMatch = false;
                }
            }

            if (matchesFound == 8)
            {
                matchesFound = 0;
                AnimalButtons.IsVisible = false;
                PlayAgainButton.IsVisible = true;
            }
        }
    }
}
