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

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            // You can also track an event with no dictionary
			Analytics.TrackEvent("Button Clicked", new Dictionary<string, string> {
				{ "Category", "User" },
                { "Value", new Random().Next(0,10).ToString()}
			});

            var action = await DisplayActionSheet("Action Sheet", "Cancel", null, new string[]{
                "Action 1",
                "Action 2"
            });

            if(action == "Action 1")
            {
                // do something with action 1
                await Navigation.PushModalAsync(new MyPage());
            }
            else if (action  == "Action 2")
            {
                // do something with action 2
            }
        }
    }
}
