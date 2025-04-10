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

        private void Button_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
