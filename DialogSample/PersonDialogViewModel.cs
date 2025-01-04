﻿using CommunityToolkit.Mvvm.ComponentModel;
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
    public event EventHandler<DialogRequestCloseEventArgs> RequestClosed;

    [ObservableProperty]
     PersonViewModel _person = new PersonViewModel();

    [RelayCommand]
     void Confirm()
    {
        RequestClosed?.Invoke(this, new DialogRequestCloseEventArgs(true));
    }

    [RelayCommand]
    void Cancel()
    {
        RequestClosed?.Invoke(this, new DialogRequestCloseEventArgs(false));
    }
}