using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogSample.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogSample;

internal partial class MainViewModel:ObservableObject
{
    public MainViewModel(IDialogService dialog)
    {
        _dialog = dialog;
    }

    [ObservableProperty]
    ObservableCollection<PersonViewModel> _persons = [];
    private readonly IDialogService _dialog;

    [RelayCommand]
    void Show()
    {
        var model=new PersonDialogViewModel();
        var result= _dialog.ShowDialog(model);

        if(result.HasValue && result.Value)
        {
            Persons.Add(model.Person);
        }
    }
}
