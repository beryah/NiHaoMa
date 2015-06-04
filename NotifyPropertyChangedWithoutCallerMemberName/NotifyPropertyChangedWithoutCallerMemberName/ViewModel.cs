using System;
using System.ComponentModel;
using System.Linq;

namespace NotifyPropertyChangedWithoutCallerMemberName
{
  public class ViewModel : INotifyPropertyChanged
  {
    private string _text;

    public string TextXX
    {
      get { return _text; }
      set
      {
        _text = value;
        OnPropertyChanged(() => TextXX);
      }
    }

    public void Loaded()
    {
      TextXX = "Hello!!";
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    private void OnPropertyChanged(Func<object> func)
    {
      var propertyName = func.Method.Name.Split(new[] { "<set_", ">" }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();

      if (!string.IsNullOrEmpty(propertyName))
      {
        OnPropertyChanged(propertyName);
      }
    }
  }
}