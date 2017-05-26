using System;
using XF.Contatos.Model;

namespace XF.Contatos.ViewModel
{
    public class DetailViewModel
    {
        #region Propriedades
        public String Name { get; set; }
        #endregion

        public DetailViewModel(Detail detail)
        {
            this.Name = detail.Name;
        }

        public static Detail GetDetail(XF.Contatos.Model.Contato contato)
        {
            var detail = new Detail()
            {
                Name = contato.Nome
            };

            return detail;
        }
    }
}
