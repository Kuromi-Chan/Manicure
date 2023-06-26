using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps;

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            JsonService JsonServiceNailExtension = new JsonService("NailExtensions.json");
            NailExtensionGrid.ItemsSource = JsonServiceNailExtension.ReadAllNailExtensions();
            NailExtensionGrid.DataContext = JsonServiceNailExtension.ReadAllNailExtensions();
            var mailext = JsonServiceNailExtension.ReadAllNailExtensions();
            foreach (var a in mailext)
                MaterialCBox.Items.Add(a.Material.ToString());


           JsonService JsonServiceNailStrengthenings = new JsonService("NailStrengthenings.json");
            NailStrengtheningsGrid.ItemsSource = JsonServiceNailStrengthenings.ReadAllNailStrengthenings();
            NailStrengtheningsGrid.DataContext = JsonServiceNailStrengthenings.ReadAllNailStrengthenings();
            var smailext = JsonServiceNailStrengthenings.ReadAllNailStrengthenings();
            foreach (var a in smailext)
                MaterialCBox3.Items.Add(a.Material.ToString());





            JsonService JsonServiceManicures = new JsonService("Manicures.json");
            ManicuresGrid.ItemsSource = JsonServiceManicures.ReadAllManicures();
            ManicuresGrid.DataContext = JsonServiceManicures.ReadAllManicures();


            JsonService JsonServiceDesigns = new JsonService("Designs.json");
            DesignsGrid.ItemsSource = JsonServiceDesigns.ReadAllDesigns();
            DesignsGrid.DataContext = JsonServiceDesigns.ReadAllDesigns();
            var toto = JsonServiceDesigns.ReadAllDesigns(); 
            foreach(var i in toto)
            {

            }


            JsonService JsonServicNailCoatings = new JsonService("NailCoatings.json");
            NailCoaingsGrid.ItemsSource = JsonServicNailCoatings.ReadAllNailCoaings();
            NailCoaingsGrid.DataContext = JsonServicNailCoatings.ReadAllNailCoaings();
            var m2ailext = JsonServicNailCoatings.ReadAllNailCoaings();
            foreach (var a in m2ailext)
                MaterialCBox4.Items.Add(a.Material.ToString());



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

        public void AdsToResultGrid(string service, double price) {

            ResultsGrid.Items.Add(new
            {
                Service = service,
                Price = price
            });
            double totalSum = Convert.ToDouble(ResultPrice.Content);
            ResultPrice.Content = (totalSum + price).ToString();

            JsonService js = new JsonService("SelectedServices.json");
            js.AddToSelectedServices(service, price);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(
   1300, 1300, 96, 96, PixelFormats.Default);
            renderTargetBitmap.Render(forPrinting);
            PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                PrintQueue printQueue = printDialog.PrintQueue;
                XpsDocumentWriter xpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);

                FixedDocument fixedDocument = new FixedDocument();
                PageContent pageContent = new PageContent();
                FixedPage fixedPage = new FixedPage();

                fixedPage.Width = 1122.5; // 297 мм в пикселях при разрешении 96 dpi
                fixedPage.Height = 1587.5; // 420 мм в пикселях при разрешении 96 dpi


                fixedPage.Children.Add(new Image { Source = renderTargetBitmap });
                ((IAddChild)pageContent).AddChild(fixedPage);
                fixedDocument.Pages.Add(pageContent);


                // Напечатайте документ
                xpsDocumentWriter.Write(fixedDocument);
            }
        }

        private void KeyTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            KeyTBox.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string keyWord = "";
            string material = "";
            string durationDo = "";
            double priceDo = 0;

            if (!string.IsNullOrEmpty(KeyTBox.Text) && KeyTBox.Text != "Введите название услуги")
                keyWord = KeyTBox.Text;
            if (MaterialCBox.SelectedItem != null)
            {
                
                material = MaterialCBox.SelectedValue as string;
            }

            if (duraionCBox.SelectedItem != null)
            {
                int leng = duraionCBox.SelectedItem.ToString().Length - 38;
                durationDo = duraionCBox.SelectedItem.ToString().Substring(38, leng);
            }
            if (PriceCBox.SelectedItem != null)
            {
                string a = PriceCBox.SelectedItem.ToString().Substring(38, 2);
                priceDo = Convert.ToDouble(a);
            }

            JsonService JsonServiceNailExtension = new JsonService("NailExtensions.json");
            NailExtensionGrid.DataContext = null;
            NailExtensionGrid.ItemsSource = null;
            NailExtensionGrid.ItemsSource = JsonServiceNailExtension.SortByFiltersNailExtension(keyWord, material, durationDo, priceDo);
            NailExtensionGrid.DataContext = JsonServiceNailExtension.SortByFiltersNailExtension(keyWord, material, durationDo, priceDo);
        }

        private void deleteFilter_Click(object sender, RoutedEventArgs e)
        {
            MaterialCBox.SelectedValue = null;
            PriceCBox.SelectedValue = null;
            duraionCBox.SelectedValue = null;



            string keyWord = "";
            string material = "";
            string durationDo = "";
            double priceDo = 0;

            if (!string.IsNullOrEmpty(KeyTBox.Text) && KeyTBox.Text != "Введите название услуги")
                keyWord = KeyTBox.Text;
            if (MaterialCBox.SelectedItem != null)
            {
          
                material = MaterialCBox.SelectedValue as string;
            }
               
            if (duraionCBox.SelectedItem != null)
            {
                int leng = duraionCBox.SelectedItem.ToString().Length - 38;
                durationDo = duraionCBox.SelectedItem.ToString().Substring(38, leng);
            }
            if (PriceCBox.SelectedItem != null)
            {
                string a = PriceCBox.SelectedItem.ToString().Substring(38, 2);
                priceDo = Convert.ToDouble(a);
            }

            JsonService JsonServiceNailExtension = new JsonService("NailExtensions.json");
            NailExtensionGrid.DataContext = null;
            NailExtensionGrid.ItemsSource = null;
            NailExtensionGrid.ItemsSource = JsonServiceNailExtension.SortByFiltersNailExtension(keyWord, material, durationDo, priceDo);
            NailExtensionGrid.DataContext = JsonServiceNailExtension.SortByFiltersNailExtension(keyWord, material, durationDo, priceDo);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string keyWord = "";
            string durationDo = "";
            double priceDo = 0;

            if (!string.IsNullOrEmpty(KeyTBox2.Text) && KeyTBox2.Text != "Введите название услуги")
                keyWord = KeyTBox2.Text;
            if (durationCBox2.SelectedItem != null)
            {
                int leng = durationCBox2.SelectedItem.ToString().Length - 38;
                durationDo = durationCBox2.SelectedItem.ToString().Substring(38, leng);
            }
            if (PriceCBox2.SelectedItem != null)
            {
                string a = PriceCBox2.SelectedItem.ToString().Substring(38, 2);
                priceDo = Convert.ToDouble(a);
            }

            JsonService JsonServiceManicure = new JsonService("Manicures.json");
            ManicuresGrid.DataContext = null;
            ManicuresGrid.ItemsSource = null;
            ManicuresGrid.ItemsSource = JsonServiceManicure.SortByFiltersManicure(keyWord, durationDo, priceDo);
            ManicuresGrid.DataContext = JsonServiceManicure.SortByFiltersManicure(keyWord, durationDo, priceDo);

        }

        private void deleteFilter2_Click(object sender, RoutedEventArgs e)
        {
            durationCBox2.SelectedValue = null;
            PriceCBox2.SelectedValue = null;



            string keyWord = "";
            string durationDo = "";
            double priceDo = 0;

            if (!string.IsNullOrEmpty(KeyTBox2.Text) && KeyTBox2.Text != "Введите название услуги")
                keyWord = KeyTBox2.Text;
            if (durationCBox2.SelectedItem != null)
            {
                int leng = durationCBox2.SelectedItem.ToString().Length - 38;
                durationDo = durationCBox2.SelectedItem.ToString().Substring(38, leng); 
            }
            if (PriceCBox2.SelectedItem != null)
            {
                string a = PriceCBox2.SelectedItem.ToString().Substring(38, 2);
                priceDo = Convert.ToDouble(a);
            }

            JsonService JsonServiceManicure = new JsonService("Manicures.json");
            ManicuresGrid.DataContext = null;
            ManicuresGrid.ItemsSource = null;
            ManicuresGrid.ItemsSource = JsonServiceManicure.SortByFiltersManicure(keyWord, durationDo, priceDo);
            ManicuresGrid.DataContext = JsonServiceManicure.SortByFiltersManicure(keyWord, durationDo, priceDo); 

        }

        private void KeyTBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            KeyTBox2.Text = "";
        }

        private void KeyTBox3_GotFocus(object sender, RoutedEventArgs e)
        {
            KeyTBox3.Text = "";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            string keyWord = "";
            string material = "";
            string durationDo = "";
            double priceDo = 0;

            if (!string.IsNullOrEmpty(KeyTBox3.Text) && KeyTBox3.Text != "Введите название услуги")
                keyWord = KeyTBox3.Text;
            if (MaterialCBox3.SelectedItem != null)
            {

                material = MaterialCBox3.SelectedValue as string;
            }

            if (durationCBox3.SelectedItem != null)
            {
                int leng = durationCBox3.SelectedItem.ToString().Length - 38;
                durationDo = durationCBox3.SelectedItem.ToString().Substring(38, leng);
            }
            if (PriceCBox3.SelectedItem != null)
            {
                string a = PriceCBox3.SelectedItem.ToString().Substring(38, 2);
                priceDo = Convert.ToDouble(a);
            }

            JsonService JsonServiceNailExtension = new JsonService("NailStrengthenings.json");
            NailStrengtheningsGrid.DataContext = null;
            NailStrengtheningsGrid.ItemsSource = null;
            NailStrengtheningsGrid.ItemsSource = JsonServiceNailExtension.SortByFiltersNailStrengthening(keyWord, material, durationDo, priceDo);
            NailStrengtheningsGrid.DataContext = JsonServiceNailExtension.SortByFiltersNailStrengthening(keyWord, material, durationDo, priceDo);
        }

        private void deleteFilter23_Click(object sender, RoutedEventArgs e)
        {

            MaterialCBox3.SelectedValue = null;
            PriceCBox3.SelectedValue = null;
            durationCBox3.SelectedValue = null;


            string keyWord = "";
            string material = "";
            string durationDo = "";
            double priceDo = 0;

            if (!string.IsNullOrEmpty(KeyTBox3.Text) && KeyTBox3.Text != "Введите название услуги")
                keyWord = KeyTBox3.Text;
            if (MaterialCBox3.SelectedItem != null)
            {

                material = MaterialCBox3.SelectedValue as string;
            }

            if (durationCBox3.SelectedItem != null)
            {
                int leng = durationCBox3.SelectedItem.ToString().Length - 38;
                durationDo = durationCBox3.SelectedItem.ToString().Substring(38, leng);
            }
            if (PriceCBox3.SelectedItem != null)
            {
                string a = PriceCBox3.SelectedItem.ToString().Substring(38, 2);
                priceDo = Convert.ToDouble(a);
            }

            JsonService JsonServiceNailExtension = new JsonService("NailStrengthenings.json");
            NailStrengtheningsGrid.DataContext = null;
            NailStrengtheningsGrid.ItemsSource = null;
            NailStrengtheningsGrid.ItemsSource = JsonServiceNailExtension.SortByFiltersNailStrengthening(keyWord, material, durationDo, priceDo);
            NailStrengtheningsGrid.DataContext = JsonServiceNailExtension.SortByFiltersNailStrengthening(keyWord, material, durationDo, priceDo);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string keyWord = "";
            string material = "";
            string durationDo = "";
            double priceDo = 0;

            if (!string.IsNullOrEmpty(KeyTBox4.Text) && KeyTBox4.Text != "Введите название услуги")
                keyWord = KeyTBox4.Text;
            if (MaterialCBox4.SelectedItem != null)
            {

                material = MaterialCBox4.SelectedValue as string;
            }

            if (durationCBox4.SelectedItem != null)
            {
                int leng = durationCBox4.SelectedItem.ToString().Length - 38;
                durationDo = durationCBox4.SelectedItem.ToString().Substring(38, leng);
            }
            if (PriceCBox4.SelectedItem != null)
            {
                string a = PriceCBox4.SelectedItem.ToString().Substring(38, 2);
                priceDo = Convert.ToDouble(a);
            }

            JsonService JsonServiceNailExtension = new JsonService("NailCoatings.json");
            NailCoaingsGrid.DataContext = null;
            NailCoaingsGrid.ItemsSource = null;
            NailCoaingsGrid.ItemsSource = JsonServiceNailExtension.SortByFiltersNailCoating(keyWord, material, durationDo, priceDo);
            NailCoaingsGrid.DataContext = JsonServiceNailExtension.SortByFiltersNailCoating(keyWord, material, durationDo, priceDo);
        }

        private void deleteFilter22_Click(object sender, RoutedEventArgs e)
        {
            MaterialCBox4.SelectedValue = null;
            PriceCBox4.SelectedValue = null;
            durationCBox4.SelectedValue = null;


            string keyWord = "";
            string material = "";
            string durationDo = "";
            double priceDo = 0;

            if (!string.IsNullOrEmpty(KeyTBox4.Text) && KeyTBox4.Text != "Введите название услуги")
                keyWord = KeyTBox4.Text;
            if (MaterialCBox4.SelectedItem != null)
            {

                material = MaterialCBox4.SelectedValue as string;
            }

            if (durationCBox4.SelectedItem != null)
            {
                int leng = durationCBox4.SelectedItem.ToString().Length - 38;
                durationDo = durationCBox4.SelectedItem.ToString().Substring(38, leng);
            }
            if (PriceCBox4.SelectedItem != null)
            {
                string a = PriceCBox4.SelectedItem.ToString().Substring(38, 2);
                priceDo = Convert.ToDouble(a);
            }

            JsonService JsonServiceNailExtension = new JsonService("NailCoatings.json");
            NailCoaingsGrid.DataContext = null;
            NailCoaingsGrid.ItemsSource = null;
            NailCoaingsGrid.ItemsSource = JsonServiceNailExtension.SortByFiltersNailCoating(keyWord, material, durationDo, priceDo);
            NailCoaingsGrid.DataContext = JsonServiceNailExtension.SortByFiltersNailCoating(keyWord, material, durationDo, priceDo);
        }

        private void KeyTBox4_GotFocus(object sender, RoutedEventArgs e)
        {
            KeyTBox4.Text = "";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string keyWord = "";
            List<string> selectedColors = new List<string>();
            string style = "";
            double priceDo = 0;

            if (!string.IsNullOrEmpty(KeyTBox5.Text) && KeyTBox5.Text != "Введите название услуги")
                keyWord = KeyTBox5.Text;
            if (ColorListBox.SelectedItems.Count != 0)
            {
                foreach (ListBoxItem item in ColorListBox.SelectedItems)
                {
                    selectedColors.Add(item.Content.ToString());
                }
            }

            if (StyleCB.SelectedItem != null)
            {
                style = StyleCB.SelectedValue as string;
            }
            if (PriceCBox4.SelectedItem != null)
            {
                string a = PriceCBox4.SelectedItem.ToString().Substring(38, 2);
                priceDo = Convert.ToDouble(a);
            }

            JsonService JsonServiceDesigns = new JsonService("Designs.json");
            DesignsGrid.DataContext = null;
            DesignsGrid.ItemsSource = null;
            DesignsGrid.ItemsSource = JsonServiceDesigns.SortByFiltersDesign(keyWord, selectedColors, style, priceDo);
            DesignsGrid.DataContext = JsonServiceDesigns.SortByFiltersDesign(keyWord, selectedColors, style, priceDo);
        }

        private void deleteFilter212_Click(object sender, RoutedEventArgs e)
        {
            StyleCB.SelectedValue = null;
            PriceCBox5.SelectedValue = null;
            ColorListBox.SelectedItems.Clear();


            string keyWord = "";
            List<string> selectedColors = new List<string>();
            string style = "";
            double priceDo = 0;

            if (!string.IsNullOrEmpty(KeyTBox5.Text) && KeyTBox5.Text != "Введите название услуги")
                keyWord = KeyTBox5.Text;
            if (selectedColors.Count != 0)
            {
                foreach (ListBoxItem item in ColorListBox.SelectedItems)
                {
                    selectedColors.Add(item.Content.ToString());
                }
            }

            if (StyleCB.SelectedItem != null)
            {
                style = StyleCB.SelectedValue as string;
            }
            if (PriceCBox4.SelectedItem != null)
            {
                string a = PriceCBox4.SelectedItem.ToString().Substring(38, 2);
                priceDo = Convert.ToDouble(a);
            }

            JsonService JsonServiceDesigns = new JsonService("Designs.json");
            DesignsGrid.DataContext = null;
            DesignsGrid.ItemsSource = null;
            DesignsGrid.ItemsSource = JsonServiceDesigns.SortByFiltersDesign(keyWord, selectedColors, style, priceDo);
            DesignsGrid.DataContext = JsonServiceDesigns.SortByFiltersDesign(keyWord, selectedColors, style, priceDo);

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(LoginTB.Text) && !string.IsNullOrEmpty(PassTBox.Password))
            {
                if(LoginTB.Text == "123" && PassTBox.Password == "123")
                {
                   
                    AdminPanel a = new AdminPanel();
                    a.Show();
                    Close();
                }
            }
        }
    }
}

