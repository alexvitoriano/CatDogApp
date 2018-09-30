using CatDog.Model.Breed;
using CatDog.ViewModel.Animal;
using System.Linq;
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
                    var page = new BreedDetailView(animal.Breeds.FirstOrDefault(), animal.Url);
                    Navigation.PushModalAsync(page);
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
            
            if (!isDog)
                this.Icon = "ico_tabcat.png";
            else
            {
                this.Icon = "ico_tabdog.png";
                lstBreed.ItemSelected += OnSelection;
                lstBreed.ItemAppearing += (sender, e) =>
                {
                    if (VM.IsBusy || VM.Animals.Count == 0)
                        return;

                    //hit bottom!
                    if ((AnimalModel)e.Item == VM.Animals[VM.Animals.Count - 1])
                    {
                        VM.GetAnimalsCommand.Execute(null);
                    }
                };

            }
            
            base.OnAppearing();

        }
    }
}