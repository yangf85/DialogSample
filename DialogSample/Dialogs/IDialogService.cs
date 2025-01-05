using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DialogSample.Dialogs;

internal interface IDialogService
{
    void Register<TViewModel, TDialog>() where TViewModel : IDialogRequestClose where TDialog : IDialogWindow, new();

    bool? ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : IDialogRequestClose;
}

internal class DialogService : IDialogService
{
    IDictionary<Type, Type> _dialogs = new Dictionary<Type, Type>();

    Window _owner;

    public DialogService(Window owner)
    {
        _owner = owner;
    }

    public void Register<TViewModel, TDialog>()
                where TViewModel : IDialogRequestClose
        where TDialog : IDialogWindow, new()
    {
        _dialogs[typeof(TViewModel)] = typeof(TDialog);
    }

    public bool? ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : IDialogRequestClose
    {
        var dialogType = _dialogs[typeof(TViewModel)];
        var dialog = (IDialogWindow)Activator.CreateInstance(dialogType);

        dialog.Owner = _owner;
        dialog.DataContext = viewModel;

        viewModel.RequestClosed += CreateHandle(viewModel, dialog);//挂载事件方法

        return dialog.ShowDialog();//显示模态对话框，不可使用Window.Show方法
    }

    private static EventHandler<DialogRequestCloseEventArgs> CreateHandle<TViewModel>(TViewModel viewModel, IDialogWindow dialog) where TViewModel : IDialogRequestClose
    {
        void Handle(object sender, DialogRequestCloseEventArgs e)
        {
            viewModel.RequestClosed -= Handle;//移除事件方法

            if (e.DialogResult.HasValue)
            {
                dialog.DialogResult = e.DialogResult;//关闭对话框 返回结果
            }
            else
            {
                dialog.Close();//直接关闭对话框
            }
        }

        return Handle;
    }
}