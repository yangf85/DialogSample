namespace DialogSample.Dialogs;

public class DialogRequestCloseEventArgs
{
    public bool? DialogResult { get;private set; }

    public  DialogRequestCloseEventArgs(bool? dialogResult)
    {
        DialogResult = dialogResult;
    }
}