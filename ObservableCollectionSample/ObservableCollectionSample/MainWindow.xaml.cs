using System.Windows;

namespace ObservableCollectionSample
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

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
      var vm = new ViewModel();

      vm.Add = t =>
      {
        this.Dispatcher.Invoke(() =>
        {
          vm.Items.Add(t);
        });
      };

      this.DataContext = vm;

      await vm.GoAsync();
    }
  }
}