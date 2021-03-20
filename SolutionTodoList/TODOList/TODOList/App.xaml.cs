using System;
using TODOList.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TODOList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new TarefaPageView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
