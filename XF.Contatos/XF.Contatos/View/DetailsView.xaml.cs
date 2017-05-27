using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Contatos.ViewModel;
using XF.Contatos.API;

namespace XF.Contatos.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsView : ContentPage
    {
        DetailViewModel vmDetail;

        public DetailsView(XF.Contatos.Model.Contato contato)
        {
            var detail = DetailViewModel.GetDetail(contato);
            vmDetail = new DetailViewModel(detail);
            BindingContext = vmDetail;

            InitializeComponent();
        }

		private void btnCamera_Clicked(object sender, EventArgs e)
		{
			ICamera capturar = DependencyService.Get<ICamera>();
			capturar.CapturarFoto();

			MessagingCenter.Subscribe<ICamera, string>(this, "cameraFoto",
				(objeto, image) =>
				{
					this.imgFoto.Source = ImageSource.FromFile(image);
				});
		}

		private void btnSelecionar_Clicked(object sender, EventArgs e)
		{
			ICamera capturar = DependencyService.Get<ICamera>();
			capturar.SelecionarFoto();

			MessagingCenter.Subscribe<ICamera, string>(this, "cameraFoto",
				(objeto, image) =>
				{
					this.imgFoto.Source = ImageSource.FromFile(image);
				});
		}

		private void btnCoordenada_Clicked(object sender, EventArgs e)
		{
			ILocalizacao geolocation = DependencyService.Get<ILocalizacao>();
			geolocation.GetCoordenada();

            this.loading.IsRunning = true;

			MessagingCenter.Subscribe<ILocalizacao, Coordenada>(this, "coordenada",
				(objeto, geo) =>
				{
                    lblLatitude.Text = geo.Latitude;
                    lblLongitude.Text = geo.Longitude;
                    this.loading.IsRunning = false;
                    DisplayMap(geo);
				});
		}

        private async void DisplayMap(Coordenada coord)
        {
            await Navigation.PushAsync(new MapView(coord));
        }
    }
}
