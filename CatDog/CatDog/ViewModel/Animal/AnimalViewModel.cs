using System;
using System.Collections.Generic;
using System.Text;

namespace CatDog.ViewModel.Animal
{
    public class AnimalViewModel
    {
        private bool isDog;

        public bool IsDog
        {
            get { return isDog; }
            set { SetProperty(ref isDog, value); }
        }
    }
}
