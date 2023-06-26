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
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {

        public string imagefileName { get; set; }

        public AdminPanel()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            JsonService jsonService = new JsonService("SelectedServices.json");
            jsonService.XMLConverter();
          


            JsonService JsonServiceNailExtension = new JsonService("NailExtensions.json");
            NailExtensionGrid.ItemsSource = JsonServiceNailExtension.ReadAllNailExtensions();
            NailExtensionGrid.DataContext = JsonServiceNailExtension.ReadAllNailExtensions();
            
           


            JsonService JsonServiceNailStrengthenings = new JsonService("NailStrengthenings.json");
            NailStrengtheningsGrid.ItemsSource = JsonServiceNailStrengthenings.ReadAllNailStrengthenings();
            NailStrengtheningsGrid.DataContext = JsonServiceNailStrengthenings.ReadAllNailStrengthenings();
            




            JsonService JsonServiceManicures = new JsonService("Manicures.json");
            ManicuresGrid.ItemsSource = JsonServiceManicures.ReadAllManicures();
            ManicuresGrid.DataContext = JsonServiceManicures.ReadAllManicures();


            JsonService JsonServiceDesigns = new JsonService("Designs.json");
            DesignsGrid.ItemsSource = JsonServiceDesigns.ReadAllDesigns();
            DesignsGrid.DataContext = JsonServiceDesigns.ReadAllDesigns();
           


            JsonService JsonServicNailCoatings = new JsonService("NailCoatings.json");
            NailCoaingsGrid.ItemsSource = JsonServicNailCoatings.ReadAllNailCoaings();
            NailCoaingsGrid.DataContext = JsonServicNailCoatings.ReadAllNailCoaings();
       


        }


        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

            NailExtension selectedNailExtension = (sender as FrameworkElement).DataContext as NailExtension;
            JsonService JsonServiceNailExtension = new JsonService("NailExtensions.json");
            JsonServiceNailExtension.DeleteNailExtension(selectedNailExtension);

            NailExtensionGrid.ItemsSource = null;
            NailExtensionGrid.DataContext = null;
            NailExtensionGrid.ItemsSource = JsonServiceNailExtension.ReadAllNailExtensions();
            NailExtensionGrid.DataContext = JsonServiceNailExtension.ReadAllNailExtensions();
        }

        private void deleteButton_Click_1(object sender, RoutedEventArgs e)
        {
            Manicure selectedManicure = (sender as FrameworkElement).DataContext as Manicure;
            JsonService JsonServiceManicures = new JsonService("Manicures.json");
            JsonServiceManicures.DeleteManicure(selectedManicure);

            ManicuresGrid.ItemsSource = null;
            ManicuresGrid.DataContext = null;
            ManicuresGrid.ItemsSource = JsonServiceManicures.ReadAllManicures();
            ManicuresGrid.DataContext = JsonServiceManicures.ReadAllManicures();
        }

        private void deleteButton_Click_2(object sender, RoutedEventArgs e)
        {
            NailStrengthening selectedNailStrengthening = (sender as FrameworkElement).DataContext as NailStrengthening;
            JsonService JsonServiceNailStrengthenings = new JsonService("NailStrengthenings.json");
            JsonServiceNailStrengthenings.DeleteNailStrengthening(selectedNailStrengthening);


            NailStrengtheningsGrid.ItemsSource = null;
            NailStrengtheningsGrid.DataContext = null;
            NailStrengtheningsGrid.ItemsSource = JsonServiceNailStrengthenings.ReadAllNailStrengthenings();
            NailStrengtheningsGrid.DataContext = JsonServiceNailStrengthenings.ReadAllNailStrengthenings();

        }

        private void deleteButton_Click_3(object sender, RoutedEventArgs e)
        {
            NailCoating selectedNailCoating = (sender as FrameworkElement).DataContext as NailCoating;
            JsonService JsonServicNailCoatings = new JsonService("NailCoatings.json");
            JsonServicNailCoatings.DeleteNailCoating(selectedNailCoating);


            NailCoaingsGrid.ItemsSource = null;
            NailCoaingsGrid.DataContext = null;
            NailCoaingsGrid.ItemsSource = JsonServicNailCoatings.ReadAllNailCoaings();
            NailCoaingsGrid.DataContext = JsonServicNailCoatings.ReadAllNailCoaings();


        }

        private void deleteButton_Click_4(object sender, RoutedEventArgs e)
        {
            Design selectedDesign = (sender as FrameworkElement).DataContext as Design;
            JsonService JsonServiceDesigns = new JsonService("Designs.json");
            JsonServiceDesigns.DeleteDesign(selectedDesign);


            DesignsGrid.ItemsSource = null;
            DesignsGrid.DataContext = null;
            DesignsGrid.ItemsSource = JsonServiceDesigns.ReadAllDesigns();
            DesignsGrid.DataContext = JsonServiceDesigns.ReadAllDesigns();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(serviceNameTB.Text) && !string.IsNullOrEmpty(materialTB.Text)
                && !string.IsNullOrEmpty(priceTB.Text) && !string.IsNullOrEmpty(durationTB.Text)
                && !string.IsNullOrEmpty(descriptionTB.Text))
            {
                NailExtension nailEx = new NailExtension(Convert.ToDouble(priceTB.Text), materialTB.Text, durationTB.Text, serviceNameTB.Text, descriptionTB.Text, imagefileName);
                JsonService JsonServiceNailExtension = new JsonService("NailExtensions.json");
                JsonServiceNailExtension.AddNewNailExtension(nailEx);



                NailExtensionGrid.ItemsSource = null;
                NailExtensionGrid.DataContext = null;
                NailExtensionGrid.ItemsSource = JsonServiceNailExtension.ReadAllNailExtensions();
                NailExtensionGrid.DataContext = JsonServiceNailExtension.ReadAllNailExtensions();

                serviceNameTB.Text = "";
                materialTB.Text = "";
                priceTB.Text = "";
                durationTB.Text = "";
                descriptionTB.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(serviceNameTB2.Text) 
               && !string.IsNullOrEmpty(priceTB2.Text) && !string.IsNullOrEmpty(durationTB2.Text)
               && !string.IsNullOrEmpty(descriptionTB2.Text))
            {
                Manicure manicurelEx = new Manicure(serviceNameTB2.Text, descriptionTB2.Text, Convert.ToDouble(priceTB2.Text), durationTB2.Text, imagefileName);
                JsonService JsonServiceManicures = new JsonService("Manicures.json");
                JsonServiceManicures.AddNewManicure(manicurelEx);

                ManicuresGrid.ItemsSource = null;
                ManicuresGrid.DataContext = null;
                ManicuresGrid.ItemsSource = JsonServiceManicures.ReadAllManicures();
                ManicuresGrid.DataContext = JsonServiceManicures.ReadAllManicures();

                serviceNameTB2.Text = "";
                priceTB2.Text = "";
                durationTB2.Text = "";
                descriptionTB2.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(serviceNameTB3.Text) && !string.IsNullOrEmpty(materialTB3.Text)
              && !string.IsNullOrEmpty(priceTB3.Text) && !string.IsNullOrEmpty(durationTB3.Text)
              && !string.IsNullOrEmpty(descriptionTB3.Text))
            {
                NailStrengthening nailEx = new NailStrengthening(Convert.ToDouble(priceTB3.Text), materialTB3.Text, durationTB3.Text, descriptionTB3.Text, serviceNameTB3.Text, imagefileName);
                JsonService JsonServiceNailStrengthenings = new JsonService("NailStrengthenings.json");
                JsonServiceNailStrengthenings.AddNewNailStrengthening(nailEx);


                NailStrengtheningsGrid.ItemsSource = null;
                NailStrengtheningsGrid.DataContext = null;
                NailStrengtheningsGrid.ItemsSource = JsonServiceNailStrengthenings.ReadAllNailStrengthenings();
                NailStrengtheningsGrid.DataContext = JsonServiceNailStrengthenings.ReadAllNailStrengthenings();

                serviceNameTB3.Text = "";
                materialTB3.Text = "";
                priceTB3.Text = "";
                durationTB3.Text = "";
                descriptionTB3.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(serviceNameTB4.Text) && !string.IsNullOrEmpty(materialTB4.Text)
             && !string.IsNullOrEmpty(priceTB4.Text) && !string.IsNullOrEmpty(durationTB4.Text)
             && !string.IsNullOrEmpty(descriptionTB4.Text))
            {
                NailCoating nailEx = new NailCoating(serviceNameTB4.Text, Convert.ToDouble(priceTB4.Text), descriptionTB4.Text, durationTB4.Text, materialTB4.Text, imagefileName);
                JsonService JsonServicNailCoatings = new JsonService("NailCoatings.json");
                JsonServicNailCoatings.AddNewNailCoating(nailEx);


                NailCoaingsGrid.ItemsSource = null;
                NailCoaingsGrid.DataContext = null;
                NailCoaingsGrid.ItemsSource = JsonServicNailCoatings.ReadAllNailCoaings();
                NailCoaingsGrid.DataContext = JsonServicNailCoatings.ReadAllNailCoaings();


                serviceNameTB4.Text = "";
                materialTB4.Text = "";
                priceTB4.Text = "";
                durationTB4.Text = "";
                descriptionTB4.Text = "";

            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(serviceNameTB5.Text) && !string.IsNullOrEmpty(styleTB.Text)
             && !string.IsNullOrEmpty(priceTB5.Text) && !string.IsNullOrEmpty(colorsTB.Text)
             && !string.IsNullOrEmpty(descriptionTB5.Text))
            {
                Design design = new Design(serviceNameTB5.Text, styleTB.Text, colorsTB.Text, descriptionTB5.Text, Convert.ToDouble(priceTB5.Text), imagefileName);
                JsonService JsonServiceDesigns = new JsonService("Designs.json");
                JsonServiceDesigns.AddNewDesign(design);


                DesignsGrid.ItemsSource = null;
                DesignsGrid.DataContext = null;
                DesignsGrid.ItemsSource = JsonServiceDesigns.ReadAllDesigns();
                DesignsGrid.DataContext = JsonServiceDesigns.ReadAllDesigns();



                serviceNameTB5.Text = "";
                styleTB.Text = "";
                priceTB5.Text = "";
                colorsTB.Text = "";
                descriptionTB5.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // Создаем диалоговое окно для выбора файла
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            // Устанавливаем фильтр для выбора только изображений
            openFileDialog.Filter = "Изображения (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Все файлы (*.*)|*.*";

            // Показываем диалоговое окно и ждем выбора файла
            bool? result = openFileDialog.ShowDialog();

            // Если файл был выбран и нажата кнопка "ОК"
            if (result == true)
            {
                // Получаем полный путь к выбранному файлу
                string selectedFilePath = openFileDialog.FileName;

                // Получаем путь к папке bin/Debug в текущей директории проекта
                string debugFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

                // Создаем папку "papka" внутри папки bin/Debug, если она не существует
                string targetFolderPath = System.IO.Path.Combine(debugFolderPath, "images\\narashivanie");

                // Получаем имя файла из полного пути
                string fileName = System.IO.Path.GetFileName(selectedFilePath);

                // Формируем путь для сохранения файла в папке "papka"
                string targetFilePath = System.IO.Path.Combine(targetFolderPath, fileName);

                // Копируем выбранный файл в целевую папку
                System.IO.File.Copy(selectedFilePath, targetFilePath, true);

                imagefileName = fileName;
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            // Создаем диалоговое окно для выбора файла
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            // Устанавливаем фильтр для выбора только изображений
            openFileDialog.Filter = "Изображения (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Все файлы (*.*)|*.*";

            // Показываем диалоговое окно и ждем выбора файла
            bool? result = openFileDialog.ShowDialog();

            // Если файл был выбран и нажата кнопка "ОК"
            if (result == true)
            {
                // Получаем полный путь к выбранному файлу
                string selectedFilePath = openFileDialog.FileName;

                // Получаем путь к папке bin/Debug в текущей директории проекта
                string debugFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

                // Создаем папку "papka" внутри папки bin/Debug, если она не существует
                string targetFolderPath = System.IO.Path.Combine(debugFolderPath, "images\\manicure");

                // Получаем имя файла из полного пути
                string fileName = System.IO.Path.GetFileName(selectedFilePath);

                // Формируем путь для сохранения файла в папке "papka"
                string targetFilePath = System.IO.Path.Combine(targetFolderPath, fileName);

                // Копируем выбранный файл в целевую папку
                System.IO.File.Copy(selectedFilePath, targetFilePath, true);

                imagefileName = fileName;
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            // Создаем диалоговое окно для выбора файла
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            // Устанавливаем фильтр для выбора только изображений
            openFileDialog.Filter = "Изображения (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Все файлы (*.*)|*.*";

            // Показываем диалоговое окно и ждем выбора файла
            bool? result = openFileDialog.ShowDialog();

            // Если файл был выбран и нажата кнопка "ОК"
            if (result == true)
            {
                // Получаем полный путь к выбранному файлу
                string selectedFilePath = openFileDialog.FileName;

                // Получаем путь к папке bin/Debug в текущей директории проекта
                string debugFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

                // Создаем папку "papka" внутри папки bin/Debug, если она не существует
                string targetFolderPath = System.IO.Path.Combine(debugFolderPath, "images\\ukreplenie");

                // Получаем имя файла из полного пути
                string fileName = System.IO.Path.GetFileName(selectedFilePath);

                // Формируем путь для сохранения файла в папке "papka"
                string targetFilePath = System.IO.Path.Combine(targetFolderPath, fileName);

                // Копируем выбранный файл в целевую папку
                System.IO.File.Copy(selectedFilePath, targetFilePath, true);

                imagefileName = fileName;
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            // Создаем диалоговое окно для выбора файла
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            // Устанавливаем фильтр для выбора только изображений
            openFileDialog.Filter = "Изображения (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Все файлы (*.*)|*.*";

            // Показываем диалоговое окно и ждем выбора файла
            bool? result = openFileDialog.ShowDialog();

            // Если файл был выбран и нажата кнопка "ОК"
            if (result == true)
            {
                // Получаем полный путь к выбранному файлу
                string selectedFilePath = openFileDialog.FileName;

                // Получаем путь к папке bin/Debug в текущей директории проекта
                string debugFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

                // Создаем папку "papka" внутри папки bin/Debug, если она не существует
                string targetFolderPath = System.IO.Path.Combine(debugFolderPath, "images\\coating");

                // Получаем имя файла из полного пути
                string fileName = System.IO.Path.GetFileName(selectedFilePath);

                // Формируем путь для сохранения файла в папке "papka"
                string targetFilePath = System.IO.Path.Combine(targetFolderPath, fileName);

                // Копируем выбранный файл в целевую папку
                System.IO.File.Copy(selectedFilePath, targetFilePath, true);

                imagefileName = fileName;
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            // Создаем диалоговое окно для выбора файла
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            // Устанавливаем фильтр для выбора только изображений
            openFileDialog.Filter = "Изображения (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Все файлы (*.*)|*.*";

            // Показываем диалоговое окно и ждем выбора файла
            bool? result = openFileDialog.ShowDialog();

            // Если файл был выбран и нажата кнопка "ОК"
            if (result == true)
            {
                // Получаем полный путь к выбранному файлу
                string selectedFilePath = openFileDialog.FileName;

                // Получаем путь к папке bin/Debug в текущей директории проекта
                string debugFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

                // Создаем папку "papka" внутри папки bin/Debug, если она не существует
                string targetFolderPath = System.IO.Path.Combine(debugFolderPath, "images\\designs");

                // Получаем имя файла из полного пути
                string fileName = System.IO.Path.GetFileName(selectedFilePath);

                // Формируем путь для сохранения файла в папке "papka"
                string targetFilePath = System.IO.Path.Combine(targetFolderPath, fileName);

                // Копируем выбранный файл в целевую папку
                System.IO.File.Copy(selectedFilePath, targetFilePath, true);

                imagefileName = fileName;
            }
        }

        private void TabItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            Close();
        }

        private void NailExtensionGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Count > 0)
            {
                NailExtension selectedNailExtension = e.AddedItems[0] as NailExtension;
                Description description = new Description();
                description.ObjectType = selectedNailExtension;
                description.Show();
            }


            NailExtensionGrid.SelectedItem = null;
        }

        private void ManicuresGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Manicure selectedManicure = e.AddedItems[0] as Manicure;
                Description description = new Description();
                description.ObjectType = selectedManicure;
                description.Show();
            }  

            ManicuresGrid.SelectedItem = null;
        }

        private void NailStrengtheningsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                NailStrengthening selectedNailStrengthening = e.AddedItems[0] as NailStrengthening;
                Description description = new Description();
                description.ObjectType = selectedNailStrengthening;
                description.Show();
            }

            NailStrengtheningsGrid.SelectedItem = null;
        }

        private void NailCoaingsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                NailCoating selectedNailCoating = e.AddedItems[0] as NailCoating;
                Description description = new Description();
                description.ObjectType = selectedNailCoating;
                description.Show();
            }

            NailCoaingsGrid.SelectedItem = null;
        }

        private void DesignsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Count > 0)
            {
                Design selectedDesign = e.AddedItems[0] as Design;
                Description description = new Description();
                description.ObjectType = selectedDesign;
                description.Show();
            }

            DesignsGrid.SelectedItem = null;


        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            Close();
        }
    }
}
