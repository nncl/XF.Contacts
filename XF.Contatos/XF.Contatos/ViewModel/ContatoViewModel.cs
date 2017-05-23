using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XF.Contatos.Model;
using XF.Contatos.API;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Contatos.ViewModel
{
    public class ContatoViewModel : INotifyPropertyChanged
    {
        public Contato Contato { get; set; }
        public ObservableCollection<Contato> Contatos { get; set; } = new ObservableCollection<Contato>();

        // UI Events
        public OnLigarCMD OnLigarCMD { get; }
        public OnDetalheCMD OnDetalheCMD { get; }

        public ContatoViewModel()
        {
            OnLigarCMD = new OnLigarCMD(this);
            OnDetalheCMD = new OnDetalheCMD(this);
        }

        public void Ligar(Contato paramContato)
        {
            // TODO Implementar a função de ligar

            if (!string.IsNullOrWhiteSpace(paramContato.Numero))
            {
                var phone = DependencyService.Get<ILigar>();
                if (phone != null) phone.Discar(paramContato.Numero);
            }
        }

        public void GetDetalhe(Contato paramContato)
        {
            // TODO Implementar a tela que visualiza detalhes do contato
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class OnLigarCMD : ICommand
    {
        private ContatoViewModel contatoVM;
        public OnLigarCMD(ContatoViewModel paramVM)
        {
            contatoVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void DeleteCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter)
        {
            if (parameter != null) return true;

            return false;
        }
        public void Execute(object parameter)
        {
            contatoVM.Ligar(parameter as Contato);
        }
    }

    public class OnDetalheCMD : ICommand
    {
        private ContatoViewModel contatoVM;
        public OnDetalheCMD(ContatoViewModel paramVM)
        {
            contatoVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void DeleteCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter)
        {
            if (parameter != null) return true;

            return false;
        }
        public void Execute(object parameter)
        {
            contatoVM.GetDetalhe(parameter as Contato);
        }
    }
}
