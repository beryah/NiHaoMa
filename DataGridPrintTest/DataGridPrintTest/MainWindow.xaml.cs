using System.Windows;

namespace DataGridPrintTest
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

      vm.Loaded();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var a = true;

      if (a)
      {
        return;
      }

      System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
      if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
      {
        Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
        // sizing of the element.
        dataGrid1.Measure(pageSize);
        dataGrid1.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
        Printdlg.PrintVisual(dataGrid1, Title);
      }
    }
  }
}