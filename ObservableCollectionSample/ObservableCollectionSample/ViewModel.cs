using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ObservableCollectionSample
{
  public class ViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<string> items = new ObservableCollection<string>();

    public ObservableCollection<string> Items
    {
      get { return items; }
      set
      {
        items = value;
        OnPropertyChanged();
      }
    }

    public Action<string> Add { get; set; }

    public async Task GoAsync()
    {
      foreach (var i in Enumerable.Range(0, 20000))
      {
        await Task.Delay(100);
        Add(i.ToString());
      }
    }

    private void OnPropertyChanged([CallerMemberName]string name = "")
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(name));
      }
    }
  }
}