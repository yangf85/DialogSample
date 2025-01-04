using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DialogSample.Dialogs;

internal interface IDialogService
{
    void Register<TViewModel,TDialog>()where TViewModel:IDialogRequestClose where TDialog:IDialogWindow,new();

    bool? ShowDialog<TViewModel>(TViewModel viewModel)where TViewModel:IDialogRequestClose;
}

internal class DialogService : IDialogService
{
    IDictionary<Type,Type> _dialogs = new Dictionary<Type, Type>();

    public void Register<TViewModel, TDialog>()
        where TViewModel : IDialogRequestClose
        where TDialog : IDialogWindow, new()
    {
        _dialogs[typeof(TViewModel)] = typeof(TDialog);
    }
    Window _owner;
    public DialogService(Window owner)
    {
        _owner = owner;
    }

    public bool? ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : IDialogRequestClose
    {
        var dialogType = _dialogs[typeof(TViewModel)];
        var dialog = (IDialogWindow)Activator.CreateInstance(dialogType);

        dialog.Owner = _owner;
        dialog.DataContext= viewModel;

        viewModel.RequestClosed += CreateHandle(viewModel,dialog);

        return dialog.ShowDialog();
    }

    private static EventHandler<DialogRequestCloseEventArgs> CreateHandle<TViewModel>(TViewModel viewModel,IDialogWindow dialog)where TViewModel:IDialogRequestClose
    {
        void Handle(object sender, DialogRequestCloseEventArgs e)
        {
            viewModel.RequestClosed-= Handle;

            if (e.DialogResult.HasValue)
            {
                dialog.DialogResult = e.DialogResult;
            }
            else
            {
                dialog.Close();
            }
           

        }

        return Handle;
    }
}