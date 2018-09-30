using CatDog.Model.Breed;
using CatDog.ViewModel.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatDog.View.Animal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BreedDetailView : ContentPage
    {
        public BreedDetailView(BreedModel breed, string urlImg)
        {
            InitializeComponent();

            var VM = new BreedDetailViewModel(breed, urlImg);

            BindingContext = VM;
        }


    }
}