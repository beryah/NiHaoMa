﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DataGridPrintTest
{
  public class ViewModel : INotifyPropertyChanged
  {
    #region ItemsSource

    private object _ItemsSource;

    public object ItemsSource
    {
      get { return _ItemsSource; }
      set
      {
        _ItemsSource = value;
        RaisePropertyChanged("ItemsSource");
      }
    }

    #endregion ItemsSource

    public void Loaded()
    {
      var rmd = new Random();

      var items = new List<Item>();

      foreach (var i in Enumerable.Range(1, 111))
      {
        items.Add(new Item()
          {
            ID = i,
            Name = string.Format("Name_{0}", i.ToString().PadLeft(5, '0')),
            Amt = (decimal)(rmd.Next(2000, 50000) * rmd.NextDouble()),
            Date = new DateTime(rmd.Next(1992, 2054), rmd.Next(1, 13), rmd.Next(1, 29)),
          });
      }

      ItemsSource = items;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void RaisePropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }

  public class Item
  {
    public int ID { get; set; }

    public string Name { get; set; }

    public decimal Amt { get; set; }

    public DateTime Date { get; set; }
  }
}