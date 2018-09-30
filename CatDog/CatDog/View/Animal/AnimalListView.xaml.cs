using CatDog.Model.Breed;
using CatDog.ViewModel.Animal;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatDog.View.Animal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimalListView : ContentPage
    {
        public bool isDog { get; set; }

        public AnimalListView(bool _isDog)
        {
            isDog = _isDog;

            InitializeComponent();


        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            if (isDog)
            {
                var animal = (AnimalModel)e.SelectedItem;
                if (animal.Breeds != null && animal.Breeds.Count > 0)
                {

                    //Navigation.PushModalAsync(page);
                }

            }

        }

        protected override async void OnAppearing()
        {
            var VM = new AnimalViewModel();
            VM.IsDog = isDog;

            BindingContext = VM;

            await ((AnimalViewModel)BindingContext).GetAnimalAsync(); 

            lstBreed.ItemsSource = VM.Animals;

            if (isDog)
                this.Icon = "ico_tabdog.png";
            else
                this.Icon = "ico_tabcat.png";

            base.OnAppearing();

        }
    }
}