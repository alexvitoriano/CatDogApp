using CatDog.Model.Breed;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatDog.ViewModel.Animal
{
    public class BreedDetailViewModel:BaseViewModel
    {
        public BreedDetailViewModel(BreedModel breed, string urlImg)
        {
            Breed = breed;
            UrlImage = urlImg;
        }

        private BreedModel _Breed;
        public BreedModel Breed
        {
            get { return _Breed; }
            set { SetProperty(ref _Breed, value); }
        }

        private string urlImage;
        public string UrlImage
        {
            get { return urlImage; }
            set { SetProperty(ref urlImage, value); }
        }


    }
}
