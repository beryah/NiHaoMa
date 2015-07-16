using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ExportToExcelTest
{
  public class ViewModel : ViewModelBase
  {
    #region GenerateCommand

    private ICommand _GenerateCommand;

    public ICommand GenerateCommand
    {
      get
      {
        return _GenerateCommand ?? (_GenerateCommand = new RelayCommand(ExecuteGenerateCommand));
      }
    }

    #endregion GenerateCommand

    #region ExportCommand

    private ICommand _ExportCommand;

    public ICommand ExportCommand
    {
      get
      {
        return _ExportCommand ?? (_ExportCommand = new RelayCommand(ExecuteExportCommand));
      }
    }

    #endregion ExportCommand

    #region ItemsSource

    private List<Item> _ItemsSource;

    public List<Item> ItemsSource
    {
      get { return _ItemsSource; }
      set
      {
        _ItemsSource = value;
        RaisePropertyChanged("ItemsSource");
      }
    }

    #endregion ItemsSource

    private void ExecuteGenerateCommand()
    {
      var r = new Random();

      ItemsSource =
        Enumerable.Range(1, 2000)
        .Select(i => new Item()
          {
            ID = i,
            Name = string.Format("Name_{0}", i.ToString().PadLeft(5, '0')),
            Amount = r.Next(200, 60000) * r.NextDouble(),
            Date = new DateTime(r.Next(1975, 2032), r.Next(1, 13), r.Next(1, 29)),
          })
        .ToList();
    }

    private void ExecuteExportCommand()
    {
      ItemsSource = null;
    }
  }

  #region Classes

  public class RelayCommand : ICommand
  {
    public RelayCommand(Action executeMethod)
    {
      ExecuteMethod = executeMethod;
      CanExecuteMethod = () => true;
    }

    public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
    {
      ExecuteMethod = executeMethod;
      CanExecuteMethod = canExecuteMethod;
    }

    private Action ExecuteMethod { get; set; }

    private Func<bool> CanExecuteMethod { get; set; }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
      if (CanExecuteMethod != null)
      {
        return CanExecuteMethod();
      }
      else
      {
        if (CanExecuteChanged != null)
        {
          CanExecuteChanged(this, null);
        }

        return true;
      }
    }

    public void Execute(object parameter)
    {
      if (ExecuteMethod != null)
      {
        ExecuteMethod();
      }
    }
  }

  public class Item
  {
    public int ID { get; set; }

    public string Name { get; set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }
  }

  public abstract class ViewModelBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }

  #endregion Classes
}