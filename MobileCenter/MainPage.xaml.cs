using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile_Center
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
            /*
            // You can also track an event with no dictionary
			Analytics.TrackEvent("Button Clicked", new Dictionary<string, string> {
				{ "Category", "User" },
                { "Time", DateTime.UtcNow}
			});
			*/
        }
    }
}
