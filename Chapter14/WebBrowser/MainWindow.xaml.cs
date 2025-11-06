using Microsoft.Web.WebView2.Core;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebBrowser;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        InitializeAsync();
    }

    private async void InitializeAsync() {
        await Webview.EnsureCoreWebView2Async();
        Webview.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
        Webview.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
    }

    //読み込み開始したらプログレスバーを表示
    private void CoreWebView2_NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e) {
        LoadingBar.Visibility = Visibility.Visible;
        LoadingBar.IsIndeterminate = true;
    }

    //読み込み完了したらプログレスバーを非表示
    private void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e) {
        LoadingBar.Visibility = Visibility.Collapsed;
        LoadingBar.IsIndeterminate = false;
    }

    private void BackButton_Click(object sender, RoutedEventArgs e) {
        if (Webview.CanGoBack) {
            Webview.GoBack();
        }
    }

    private void FowardButton_Click(object sender, RoutedEventArgs e) {
        if (Webview.CanGoForward) {
            Webview.GoForward();
        }
    }

    private void GoButton_Click(object sender, RoutedEventArgs e) {
        var url = AddressBar.Text;

        if (string.IsNullOrWhiteSpace(url)) return;
        Webview.Source = new Uri(url);
    }
}