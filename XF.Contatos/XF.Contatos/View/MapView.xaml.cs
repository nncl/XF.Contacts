using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Xamarin.Forms;

namespace XF.Contatos.View
{
    public partial class MapView : ContentPage
    {
        public MapView(Double lat, Double lng)
        {
            InitializeComponent();

            BuildMap(lat, lng);
        }

        public void BuildMap(Double lat, Double lng)
        {
            var position = new Position(lat, lng); // Latitude, Longitude
			var pin = new Pin
			{
				Type = PinType.Place,
				Position = position,
				Label = "Hello",
				Address = "This is where you are right now, bro!!"
			};

			var map = new Map(
			MapSpan.FromCenterAndRadius(
					new Position(lat, lng), Distance.FromMiles(0.3)))
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			var stack = new StackLayout { Spacing = 0 };
            map.Pins.Add(pin);
			stack.Children.Add(map);
			Content = stack;
        }
    }
}
