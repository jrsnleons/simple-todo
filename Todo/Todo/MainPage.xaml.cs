using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Todo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            //initialize some sample data
            todo.ItemsSource = new string[] { "Do a task", "Add a task", "Create a new application", "Play Pokemon", "Pass Mobile Daevelopment Course" };
        }
        
        private void addATodo(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addTodo());
        }
    }
}
