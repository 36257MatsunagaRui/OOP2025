using CustomerApp.Data;
using Microsoft.Win32;
using SQLite;
using System.ComponentModel;
using System.IO;
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

namespace CustomerApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    private List<Customer> _customer = new List<Customer>();
    private ICollectionView _customerView;

    public MainWindow() {
        InitializeComponent();
        ReadDatabase();
        _customerView = CollectionViewSource.GetDefaultView(_customer);
        CustomerDataGrid.ItemsSource = _customer;
        Control();
    }

    private void ReadDatabase() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            _customer.Clear();
            var allCustomers = connection.Table<Customer>().ToList();
            _customer.AddRange(allCustomers);
        }
    }

    //画像選択ボタン
    private byte[]? _tempImageBytes = null;
    private void ImageButton_Click(object sender, RoutedEventArgs e) {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
        if (openFileDialog.ShowDialog() == true) {
            try {
                byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);

                _tempImageBytes = imageBytes;

                var selectedCustomer = CustomerDataGrid.SelectedItem as Customer;
                if (selectedCustomer != null) {
                    selectedCustomer.Picture = imageBytes;
                }

                // プレビュー表示
                CustomerImage.Source = ByteArrayToBitmapImage(imageBytes);

                MessageBox.Show($"画像ロードしました");
            }
            catch (Exception ex) {
                MessageBox.Show($"ファイルの読み込みエラー: {ex.Message}");
            }
        }
    }

    //更新ボタン
    private void UpdateButton_Click(object sender, RoutedEventArgs e) {
        var selectedCustomer = CustomerDataGrid.SelectedItem as Customer;
        if (selectedCustomer is null) return;

        var customerToUpdate = new Customer() {
            Id = selectedCustomer.Id,
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
            Address = AddressTextBox.Text,

            Picture = _tempImageBytes ?? selectedCustomer.Picture
        };

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();

            connection.Update(customerToUpdate);

            ReadDatabase();
            CustomerDataGrid.ItemsSource = _customer;

            CustomerDataGrid.SelectedItem = _customer.FirstOrDefault(c => c.Id == customerToUpdate.Id);
            Refresh();
            Clean();
            Control();
        }
    }

    //新規登録ボタン
    private void AddButton_Click(object sender, RoutedEventArgs e) {
        var customer = new Customer() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
            Address = AddressTextBox.Text,
            Picture = _tempImageBytes
        };

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Insert(customer);

            _tempImageBytes = null;
            CustomerImage.Source = null;

            ReadDatabase();
            CustomerDataGrid.ItemsSource = _customer;
            CustomerDataGrid.SelectedItem = _customer.FirstOrDefault(c => c.Id == customer.Id);
            Refresh();
            Clean();
            Control();
        }
    }

    //削除ボタン
    private void DeleteButton_Click(object sender, RoutedEventArgs e) {
        var item = CustomerDataGrid.SelectedItem as Customer;

        if (item == null) {
            MessageBox.Show("行を選択してください");
            return;
        }

        //データベース接続
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Delete(item); //データベースから選択されているレコードの削除
            ReadDatabase();
            CustomerDataGrid.ItemsSource = _customer;
        }

        Refresh();
        Clean();
        Control();
    }

    private void CustomerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var selectedCustomer = CustomerDataGrid.SelectedItem as Customer;

        if (_customerView != null) {
            _customerView.Filter = null;
        }

        if (selectedCustomer is null) {
            Clean();
            Control();

            if (_customerView != null) {
                _customerView.Filter = CustomerFilter;
            }

            return;
        }

        NameTextBox.Text = selectedCustomer.Name;
        PhoneTextBox.Text = selectedCustomer.Phone;
        AddressTextBox.Text = selectedCustomer.Address;

        if (selectedCustomer.Picture != null && selectedCustomer.Picture.Length > 0) {
            CustomerImage.Source = ByteArrayToBitmapImage(selectedCustomer.Picture);
        } else {
            CustomerImage.Source = null;
        }

        if (_customerView != null) {
            _customerView.Filter = CustomerFilter;
        }

        Control();
    }
    private BitmapImage ByteArrayToBitmapImage(byte[] imageData) {
        if (imageData == null || imageData.Length == 0) return null;

        var image = new BitmapImage();
        using (var mem = new MemoryStream(imageData)) {
            mem.Position = 0;
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = mem;
            image.EndInit();
        }
        image.Freeze();
        return image;
    }

    //クリア
    private void Clean() {
        NameTextBox.Text = string.Empty;
        PhoneTextBox.Text = string.Empty;
        AddressTextBox.Text = string.Empty;
        CustomerImage.Source = null;

        _tempImageBytes = null;
        CustomerDataGrid.SelectedItem = null;
    }

    //ボタン制御
    private void Control() {
        bool isSelected = CustomerDataGrid.SelectedItem != null;

        bool hasText = !string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                       !string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
                       !string.IsNullOrWhiteSpace(AddressTextBox.Text);

        DeleteButton.IsEnabled = isSelected;
        UpdateButton.IsEnabled = isSelected && hasText;
        AddButton.IsEnabled = hasText && !isSelected;
    }


    private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e) {
        Control();

        if (_customerView != null) {
            _customerView.Filter = CustomerFilter;
            _customerView.Refresh();
        }
    }

    private void NewButton_Click(object sender, RoutedEventArgs e) {
        Clean();
        Control();
    }

    private void Refresh() {
        CustomerDataGrid.ItemsSource = null;
        CustomerDataGrid.ItemsSource = _customer;
        CustomerDataGrid.Items.Refresh();
    }

    private bool CustomerFilter(object item) {
        if (string.IsNullOrEmpty(NameTextBox.Text)) {
            return true;
        }

        var customer = item as Customer;
        if (customer == null) return false;

        return customer.Name.IndexOf(NameTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
    }
}