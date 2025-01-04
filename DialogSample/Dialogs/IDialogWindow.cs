using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DialogSample.Dialogs;

internal interface IDialogWindow
{
    object DataContext { get; set; }

    bool? DialogResult { get; set; }

    Window Owner { get; set; }
    bool? ShowDialog();

    void Close();
}
