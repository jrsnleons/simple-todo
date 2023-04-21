using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class editTodo : ContentPage
	{
        private todoList item;

        public editTodo(todoList selectedItem)
        {
            InitializeComponent();

            item = selectedItem;
            BindingContext = item;
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {

            // Update the properties of the todo item
            item.title = titleEntry.Text;
            item.description = descriptionEntry.Text;

            // Navigate back to the MainPage
            Navigation.PopAsync();
        }
    }
}