using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XF.Contatos.ViewModel;

namespace XF.Contatos.View
{
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
    }
}
