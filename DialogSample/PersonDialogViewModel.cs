using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogSample.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogSample;

internal partial class PersonDialogViewModel : ObservableObject, IDialogRequestClose
{
    [ObservableProperty]
    PersonViewModel _person = new PersonViewModel();

    [RelayCommand]
    void Confirm()
    {
        RequestClosed?.Invoke(this, new DialogRequestCloseEventArgs(true));//发送关闭窗口的请求，并设置窗口关闭的结果是true
    }

    [RelayCommand]
    void Cancel()
    {
        RequestClosed?.Invoke(this, new DialogRequestCloseEventArgs(false));//发送关闭窗口的请求，并设置窗口关闭的结果是false
    }

    public event EventHandler<DialogRequestCloseEventArgs> RequestClosed;
}