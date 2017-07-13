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
using System.Threading.Tasks;

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

            // Customize Distribute Message
            Distribute.ReleaseAvailable = OnReleaseAvailable;

            // Start Mobile Center
            MobileCenter.Start("ios=1f55e7a2-0958-4dc0-ba63-cd0cb9e62988;" +
                   "uwp=7740dc08-60a3-47f0-9eb2-c602815280ad;" +
                   "android=970c6dac-5e92-4fd7-bbd8-2017d2cb3709",
                               typeof(Analytics),
                               typeof(Crashes),
                               typeof(Distribute),
                               typeof(Push));

        }

        /// <summary>
        /// Source: https://docs.microsoft.com/en-us/mobile-center/sdk/distribute/xamarin
        /// </summary>
        private bool OnReleaseAvailable(ReleaseDetails releaseDetails)
        {
            // Look at releaseDetails public properties to get version information, release notes text or release notes URL
            string versionName = releaseDetails.ShortVersion;
            string versionCodeOrBuildNumber = releaseDetails.Version;
            string releaseNotes = releaseDetails.ReleaseNotes;
            Uri releaseNotesUrl = releaseDetails.ReleaseNotesUrl;

            // custom dialog
            var title = "Version " + versionName + " available!";
            Task answer;

            // On mandatory update, user cannot postpone
            if (releaseDetails.MandatoryUpdate)
            {
                answer = Current.MainPage.DisplayAlert(title, releaseNotes, "Download and Install");
            }
            else
            {
                answer = Current.MainPage.DisplayAlert(title, releaseNotes, "Download and Install", "Maybe tomorrow...");
            }
            answer.ContinueWith((task) =>
            {
                // If mandatory or if answer was positive
                if (releaseDetails.MandatoryUpdate || (task as Task<bool>).Result)
                {
                    // Notify SDK that user selected update
                    Distribute.NotifyUpdateAction(UpdateAction.Update);
                }
                else
                {
                    // Notify SDK that user selected postpone (for 1 day)
                    // Note that this method call is ignored by the SDK if the update is mandatory
                    Distribute.NotifyUpdateAction(UpdateAction.Postpone);
                }
            });

            // Return true if you are using your own dialog, false otherwise
            return true;
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
