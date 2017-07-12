using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Azure.Mobile.Analytics;

namespace Mobile_Center
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

			var entries = new List<string>()
			{
				"Jim Fletcher",
				"Sarah Diversey",
				"Sam Wacker",
				"Evan Kedzie",
				"Eve Damon",
				"Eric Ashland",
				"Michelle Belmont",
				"Carl Clark",
                "Timothy State",
                "Tanya Sheffield",
                "Amy McClurg",
                "Wayne Lincoln",
                "Mary Wolfram",
                "Brendan Wells"
			};

			var result = from entry in entries
						 where !string.IsNullOrEmpty(entry)
						 orderby entry
						 group entry by entry[0].ToString().ToUpper() into entryGroup
						 select new Grouping<string, string>(entryGroup.Key, entryGroup);

            MyList.ItemsSource = result;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            // You can also track an event with no dictionary
			Analytics.TrackEvent("Button Clicked", new Dictionary<string, string> {
				{ "Category", "User" },
                { "Time", DateTime.UtcNow.ToString()}
			});

            DisplayActionSheet("Action Sheet", "Cancel", null, new string[]{
                "Action 1",
                "Action 2"
            });
        }
    }
}
