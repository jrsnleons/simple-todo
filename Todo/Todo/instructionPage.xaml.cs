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
    public partial class instructionPage : ContentPage
    {
        public instructionPage()
        {
            InitializeComponent();
        }
        private void closeModal(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}