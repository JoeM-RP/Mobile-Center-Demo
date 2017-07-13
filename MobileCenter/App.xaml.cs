using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile.Distribute;
using Microsoft.Azure.Mobile.Push;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Mobile_Center
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var root = new NavigationPage();
            root.PushAsync(new MainPage());

            MainPage = root;

        }

        protected override void OnStart()
        {
            // Handle when your app starts

            MobileCenter.Start("ios=1f55e7a2-0958-4dc0-ba63-cd0cb9e62988;" +
                   "uwp=7740dc08-60a3-47f0-9eb2-c602815280ad;" +
                   "android=970c6dac-5e92-4fd7-bbd8-2017d2cb3709",
                   typeof(Analytics), 
                   typeof(Crashes),
                   typeof(Distribute));

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
