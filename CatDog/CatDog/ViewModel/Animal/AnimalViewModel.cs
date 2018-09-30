using CatDog.Model.Breed;
using CatDog.Services.Breed;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CatDog.ViewModel.Animal
{
    public class AnimalViewModel : BaseViewModel
    {
        private bool isDog;
        public bool IsDog
        {
            get { return isDog; }
            set { SetProperty(ref isDog, value); }
        }
            
        public AnimalViewModel()
        {
            GetAnimalsCommand = new Command(async () => await GetAnimalAsync(), () => !IsBusy);
        }

        //Models
        public ObservableCollection<AnimalModel> Animals { get; set; }

        //Commands
        public Command GetAnimalsCommand { get; set; }

        //Services
        public AnimalServices animalService = new AnimalServices();
        
        public async Task GetAnimalAsync()
        {
            if (!IsBusy)
            {

                try
                {
                    IsBusy = true;

                    Animals = new ObservableCollection<AnimalModel>(await animalService.GetAnimalsServiceAsync(isDog));

                    if (Animals == null)
                    {
                        DisplayAlert($"CatDogApp", $"Impossible to recover this animal", $"OK");
                        return;
                    }

                    //foreach (var animal in _Animals)
                    //{
                    //    Animals.Add(animal);
                    //}
                    
                    
                }
                catch (Exception ex)
                {
                    Error = ex;
                }
                finally
                {
                    IsBusy = false;
                }

            }
        }

        
    }
}
