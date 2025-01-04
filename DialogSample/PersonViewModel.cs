using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogSample;

public partial class PersonViewModel:ObservableObject
{

    [ObservableProperty]
    string _name;
    [ObservableProperty]
    int _age;
    [ObservableProperty]
    string _address;
    [ObservableProperty]
    string _phone;
    [ObservableProperty]
    string _email;
    [ObservableProperty]
    string _website;


}
