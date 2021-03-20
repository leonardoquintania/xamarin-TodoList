using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Model;
using TODOList.Service;
using TODOList.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TODOList.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TarefaPageView : ContentPage
    {
        //private TarefaModel _tarefaInEdition;
        public TarefaPageView()
        {
            InitializeComponent();

            BindingContext = new TarefaViewModel();
        }

        //private void btnSalvarTarefa_Clicked(object sender, EventArgs e)
        //{
        //    if (_tarefaInEdition == null)
        //    {
        //        var tarefa = new TarefaModel { Description = edtTarefa.Text, Done = false };
        //        TarefaService.Instance.Save(tarefa);
        //    }
        //    else
        //    {
        //        _tarefaInEdition.Description = edtTarefa.Text;
        //        TarefaService.Instance.Update(_tarefaInEdition);
        //        _tarefaInEdition = null;
        //    }

        //    edtTarefa.Text = string.Empty;
        //    lvtTarefas.ItemsSource = TarefaService.Instance.GetListTarefa();
        //}

        //private void MenuItem_Clicked_Excluir(object sender, EventArgs e)
        //{
        //    var tarefa = (((MenuItem)sender).CommandParameter) as TarefaModel;

        //    TarefaService.Instance.Delete(tarefa);

        //    lvtTarefas.ItemsSource = TarefaService.Instance.GetListTarefa();
        //}

        //private void MenuItem_Clicked_Editar(object sender, EventArgs e)
        //{
        //    var tarefa = (((MenuItem)sender).CommandParameter) as TarefaModel;

        //    edtTarefa.Text = tarefa.Description;
        //    _tarefaInEdition = tarefa;
        //}

        //private void btnSituacao_Clicked(object sender, EventArgs e)
        //{
        //    var tarefa = (((Button)sender).CommandParameter) as TarefaModel;

        //    tarefa.Done = !tarefa.Done;
        //    TarefaService.Instance.Update(tarefa);

        //    lvtTarefas.ItemsSource = TarefaService.Instance.GetListTarefa();
        //}
    }
}