using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogSample.Dialogs;

internal interface IDialogRequestClose
{
    event EventHandler<DialogRequestCloseEventArgs> RequestClosed;
}
