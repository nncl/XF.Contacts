using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using XF.Contatos.API;

namespace XF.Contatos.View
{
    public partial class MapView : ContentPage
    {
        public MapView(Coordenada coord)
        {
            InitializeComponent();

            BuildMap(coord);
        }

        public void BuildMap(Coordenada coord)
        {
            var position = new Position(Double.Parse(coord.Latitude), Double.Parse(coord.Longitude)); // Latitude, Longitude
			var pin = new Pin
			{
				Type = PinType.Place,
				Position = position,
				Label = "Hello",
				Address = "This is where you are right now, bro!!"
			};

			var map = new Map(
			MapSpan.FromCenterAndRadius(
                    new Position(Double.Parse(coord.Latitude), Double.Parse(coord.Longitude)), Distance.FromMiles(0.3)))
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
