using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для Description.xaml
    /// </summary>
    public partial class Description : Window
    {
        public object ObjectType { get;set;}
        public Description()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ObjectType is Design)
            {

                Design obj = (Design)ObjectType;
                serviceLabel.Content = obj.Service;
                PriceLabel.Content= obj.Price;
                StyleLabel.Content = obj.Style;
                ColorLabel.Content = obj.Colors;
                DescriptionLabel.Text = obj.Description;
                MaterialLabel.Content = "Гель-лак";
                DurationLabel.Content = "Не указано";
                PhotoImage.Source = new BitmapImage(new Uri(obj.Img, UriKind.RelativeOrAbsolute));

            }
            if (ObjectType is Manicure)
            {
                Manicure obj = (Manicure)ObjectType;
                serviceLabel.Content = obj.Service;
                PriceLabel.Content = obj.Price;
                StyleLabel.Content = "Не указано";
                ColorLabel.Content = "Не указано";
                DescriptionLabel.Text = obj.Description;
                MaterialLabel.Content = "Не указан";
                DurationLabel.Content = obj.Duration;
                PhotoImage.Source = new BitmapImage(new Uri(obj.Img, UriKind.RelativeOrAbsolute));
            }
            if (ObjectType is NailCoating)
            {
                NailCoating obj = (NailCoating)ObjectType;
                serviceLabel.Content = obj.Service;
                PriceLabel.Content = obj.Price;
                StyleLabel.Content = "Не указано";
                ColorLabel.Content = "Не указано";
                DescriptionLabel.Text = obj.Description;
                MaterialLabel.Content = obj.Material;
                DurationLabel.Content = obj.Duration;
                PhotoImage.Source = new BitmapImage(new Uri(obj.Img, UriKind.RelativeOrAbsolute));
            }
            if (ObjectType is NailExtension)
            {
                NailExtension obj = (NailExtension)ObjectType;
                serviceLabel.Content = obj.Service;
                PriceLabel.Content = obj.Price;
                StyleLabel.Content = "Не указано";
                ColorLabel.Content = "Не указано";
                DescriptionLabel.Text = obj.Description;
                MaterialLabel.Content = obj.Material;
                DurationLabel.Content = obj.Duration;
                PhotoImage.Source = new BitmapImage(new Uri(obj.Img, UriKind.RelativeOrAbsolute));
            }
            if (ObjectType is NailStrengthening)
            {
                NailStrengthening obj = (NailStrengthening)ObjectType;
                serviceLabel.Content = obj.Service;
                PriceLabel.Content = obj.Price;
                StyleLabel.Content = "Не указано";
                ColorLabel.Content = "Не указано";
                DescriptionLabel.Text = obj.Description;
                MaterialLabel.Content = obj.Material;
                DurationLabel.Content = obj.Duration;
                PhotoImage.Source = new BitmapImage(new Uri(obj.Img, UriKind.RelativeOrAbsolute));

            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var mainwindow = App.Current.MainWindow as MainWindow;
            if (ObjectType is Design)
            {
                
                Design obj = (Design)ObjectType;
                mainwindow.AdsToResultGrid(obj.Service, obj.Price);
                mainwindow.ResultsGrid.Items.Refresh();
                MessageBox.Show("Успешно добавлено!");
                Close();
            }
            if (ObjectType is Manicure)
            {
                Manicure obj = (Manicure)ObjectType;
                mainwindow.AdsToResultGrid(obj.Service, obj.Price);
                mainwindow.ResultsGrid.Items.Refresh();
                MessageBox.Show("Успешно добавлено!");
                Close();
            }
            if (ObjectType is NailCoating)
            {
                NailCoating obj = (NailCoating)ObjectType;;
                mainwindow.AdsToResultGrid(obj.Service, obj.Price);
                mainwindow.ResultsGrid.Items.Refresh();
                MessageBox.Show("Успешно добавлено!");
                Close();
            }
            if (ObjectType is NailExtension)
            {
                NailExtension obj = (NailExtension)ObjectType;
                mainwindow.AdsToResultGrid(obj.Service, obj.Price);
                mainwindow.ResultsGrid.Items.Refresh();
                MessageBox.Show("Успешно добавлено!");
                Close();
            }
            if (ObjectType is NailStrengthening)
            {
                NailStrengthening obj = (NailStrengthening)ObjectType;
                mainwindow.AdsToResultGrid(obj.Service, obj.Price);
                mainwindow.ResultsGrid.Items.Refresh();
                MessageBox.Show("Успешно добавлено!");
                Close();
            }
           
        }
    }
}
