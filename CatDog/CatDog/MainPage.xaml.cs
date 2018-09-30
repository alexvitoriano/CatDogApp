using CatDog.View.Animal;
using Xamarin.Forms;

namespace CatDog
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.Title = "CatDogApp";

            Children.Add(new AnimalListView(true));
            Children.Add(new AnimalListView(false));
        }
    }
}
