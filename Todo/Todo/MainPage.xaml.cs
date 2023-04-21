using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Todo
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<todoList> myList = new ObservableCollection<todoList>();
        public MainPage()
        {
            InitializeComponent();
            todo.ItemsSource = myList;
        }
        
        private void addATodo(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addTodo(myList));
        }
        private void onDelete(object sender, EventArgs e)
        {
            var item = (sender as Button).BindingContext as todoList;
            myList.Remove(item);
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var selectedItem = e.SelectedItem as todoList;
            await Navigation.PushAsync(new editTodo(selectedItem));

            // Clear selection
            todo.SelectedItem = null;
        }

        //checks if the object from editTodo has been passed succesffuly - logs it into console
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("OnAppearing: myList count = " + myList.Count);
            foreach (var item in myList)
            {
                Debug.WriteLine("Item: " + item.title + " - " + item.description);
            }

            todo.ItemsSource = null;
            todo.ItemsSource = myList;
        }
    }
}
