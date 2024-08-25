using System;
using AutoNotify;

namespace CSharpGeneratedDemo;

// The view model we'd like to augment
public partial class ExampleViewModel
{
    [AutoNotify]
    private string _text = "private field text";

    [AutoNotify(PropertyName = "Count2")]
    private int _amount = 5;
}

public static class UseAutoNotifyGenerator
{
    public static void Run()
    {
        var vm = new ExampleViewModel();

        // we didn't explicitly create the 'Text' property, it was generated for us 
        var text = vm.Text;
        Console.WriteLine($"Text = {text}");

        // Properties can have differnt names generated based on the PropertyName argument of the attribute
        var count = vm.Count2;
        Console.WriteLine($"Count = {count}");

        // the viewmodel will automatically implement INotifyPropertyChanged
        vm.PropertyChanged += (o, e) => Console.WriteLine($"Property {e.PropertyName} was changed");
        vm.Text = "abc";
        vm.Count2 = 123;

        // Try adding fields to the ExampleViewModel class above and tagging them with the [AutoNotify] attribute
        // You'll see the matching generated properties visibile in IntelliSense in realtime
    }
}
