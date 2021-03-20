using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TODOList.Commands;
using TODOList.Model;
using TODOList.Service;
using Xamarin.Forms;

namespace TODOList.ViewModel
{
    public class TarefaViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<TarefaModel> ListaTarefa { get; set; }


        private TarefaModel _tarefaAtual;

        public TarefaModel TarefaAtual { 
            get =>_tarefaAtual;
            set 
            {
                _tarefaAtual = value;
                OnPropertyChanged();
            }
        }

        public Command  SalvarCommand { get; private set; }
        public Command EditarCommand { get; private set; }
        public Command ExcluirCommand { get; private set; }
        //public Command EditarSituacaoCommand { get; private set; }
        public ICommand EditarSituacaoCommand { get; private set; }


        public TarefaViewModel()
        {
            TarefaAtual = new TarefaModel();
            ListaTarefa = new ObservableCollection<TarefaModel>(TarefaService.Instance.GetListTarefa());

            SalvarCommand = new Command(Salvar);
            EditarCommand = new Command<TarefaModel>(Editar);

            ExcluirCommand = new Command<TarefaModel>(Excluir);

            //EditarSituacaoCommand = new Command<TarefaModel>(EditarSituacao);
            EditarSituacaoCommand = new EditarSituacaoCommand(this);

        }

        private void Salvar()
        {
            if (TarefaAtual.Id == 0)
            {
                TarefaAtual.Done = false;
                TarefaService.Instance.Save(TarefaAtual);
                ListaTarefa.Add(TarefaAtual);
            }
            else
            {
                TarefaService.Instance.Update(TarefaAtual);
                //ListaTarefa = new ObservableCollection<TarefaModel>(TarefaService.Instance.GetListTarefa()); // Joga tudo fora e cria nova lista
                var tarefa = ListaTarefa.Where(t => t.Id == TarefaAtual.Id).FirstOrDefault();
                var index = ListaTarefa.IndexOf(tarefa);

                if (tarefa != null)
                {
                    ListaTarefa.RemoveAt(index);
                    ListaTarefa.Insert(index, TarefaAtual);
                }

            }
            TarefaAtual = new TarefaModel();
        }

        private void Editar(TarefaModel tarefa) => TarefaAtual = tarefa;

        private void Excluir(TarefaModel tarefa)
        {
            TarefaService.Instance.Delete(tarefa);
            ListaTarefa.Remove(tarefa);
        }

        //private void EditarSituacao(TarefaModel tarefa)
        //{
        //    var index = ListaTarefa.IndexOf(tarefa);

        //    tarefa.Done = !tarefa.Done;
        //    TarefaService.Instance.Update(tarefa);

        //    ListaTarefa.RemoveAt(index);
        //    ListaTarefa.Insert(index, tarefa);


        //}


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
