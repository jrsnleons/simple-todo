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

            ToolbarItems.Add(new ToolbarItem("?", null, () =>
            {
                Navigation.PushModalAsync(new instructionPage());
            }));

            myList.Add(new todoList { title = "Task 1", description = "Description 1", completed = false });
            myList.Add(new todoList { title = "Task 2", description = "Description 2", completed = true });
            myList.Add(new todoList { title = "Task 3", description = "Description 3", completed = false });

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

            reloadList();
        }
        private void toggleComplete(object sender, EventArgs e)
        {
            var item = (sender as Button).BindingContext as todoList;
            item.completed = !item.completed;

            //create a new sortedList
            var sortedList = new ObservableCollection<todoList>(myList.OrderBy(x => x.completed));

            //reload
            todo.ItemsSource = null;
            todo.ItemsSource = sortedList;

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

            var sortedList = new ObservableCollection<todoList>(myList.OrderBy(x => x.completed));

            //consoles what is inside myList (remove in deployment)
            Debug.WriteLine("OnAppearing: myList count = " + myList.Count);
            foreach (var item in myList)
            {
                Debug.WriteLine("Item: " + item.title + " - " + item.description + " - " + item.completed);
            }

            todo.ItemsSource = null;
            todo.ItemsSource = sortedList;
        }
        private void reloadList()
        {
            var sortedList = new ObservableCollection<todoList>(myList.OrderBy(x => x.completed));

            todo.ItemsSource = null;
            todo.ItemsSource = sortedList;
        }
    }
}
