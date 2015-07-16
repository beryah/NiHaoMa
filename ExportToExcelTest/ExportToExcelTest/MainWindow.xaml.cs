using System.Windows;

namespace ExportToExcelTest
{
  /// <summary>
  /// MainWindow.xaml 的互動邏輯
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      var vm = new ViewModel();
      this.DataContext = vm;
    }
  }
}