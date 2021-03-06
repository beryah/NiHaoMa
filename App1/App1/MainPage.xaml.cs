﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白頁項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var colors =
                typeof(Colors)
                .GetRuntimeProperties()
                .Select(x => new DragItemViewModel()
                {
                    Name = x.Name,
                    Color = (Color)x.GetValue(null),
                });

            this.gv_1.ItemsSource = new ObservableCollection<DragItemViewModel>(colors);

            this.gv_top.ItemsSource = new ObservableCollection<DragItemViewModel>(colors);
        }

        private void AppBar_Closed(object sender, object e)
        {
            this.app_bg.Visibility = Visibility.Collapsed;
        }

        private void AppBar_Opened(object sender, object e)
        {
            this.app_bg.Visibility = Visibility.Visible;
        }
    }

    public class DragItemViewModel
    {
        public string Name { get; set; }

        public Color Color { get; set; }

        public SolidColorBrush Brush
        {
            get
            {
                return new SolidColorBrush(this.Color);
            }
        }
    }
}