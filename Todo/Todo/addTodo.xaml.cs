using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addTodo : ContentPage
    {
        private ObservableCollection<todoList> myList;
        public addTodo(ObservableCollection<todoList> list)
        {
            InitializeComponent();
            myList = list;
        }

        private async void ToAddTodo(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(titleEntry.Text))
                {
                    throw new Exception("Title cannot be empty.");
                }
                myList.Add(new todoList { title = titleEntry.Text, description = descriptionEntry.Text });
                await Navigation.PopAsync();
            }
            catch (Exception ex) 
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }



        }
    }
}