using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;


namespace Kurs
{
    internal class JsonService
    {
        string _path;
        public JsonService() { }

        public JsonService(string path)
        {
            _path = path;
        }

        public List<NailExtension> ReadAllNailExtensions()
        {
            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<NailExtension>>(fileText);
            }
        }
        public List<Manicure> ReadAllManicures()
        {
            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Manicure>>(fileText);
            }
        }
        public List<NailStrengthening> ReadAllNailStrengthenings()
        {
            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<NailStrengthening>>(fileText);
            }
        }
        public List<Design> ReadAllDesigns()
        {
            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Design>>(fileText);
            }
        }
        public List<NailCoating> ReadAllNailCoaings()
        {
            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<NailCoating>>(fileText);
            }
        }

        public void AddNewNailExtension(NailExtension el)
        {
            var fileText = "";
            using (var reader = File.OpenText(_path))
            {
                fileText = reader.ReadToEnd();
                var nailExtensions = JsonConvert.DeserializeObject<List<NailExtension>>(fileText);
                nailExtensions.Add(el);
                fileText = JsonConvert.SerializeObject(nailExtensions, Formatting.Indented);
            }
            File.WriteAllText(_path, fileText);
        }
        public void AddNewManicure(Manicure el)
        {
            var fileText = "";
            using (var reader = File.OpenText(_path))
            {
                fileText = reader.ReadToEnd();
                var nailExtensions = JsonConvert.DeserializeObject<List<Manicure>>(fileText);
                nailExtensions.Add(el);
                fileText = JsonConvert.SerializeObject(nailExtensions, Formatting.Indented);
            }
            File.WriteAllText(_path, fileText);
        }
        public void AddNewNailStrengthening(NailStrengthening el)
        {
            var fileText = "";
            using (var reader = File.OpenText(_path))
            {
                fileText = reader.ReadToEnd();
                var nailExtensions = JsonConvert.DeserializeObject<List<NailStrengthening>>(fileText);
                nailExtensions.Add(el);
                fileText = JsonConvert.SerializeObject(nailExtensions, Formatting.Indented);
            }
            File.WriteAllText(_path, fileText);
        }
        public void AddNewNailCoating(NailCoating el)
        {
            var fileText = "";
            using (var reader = File.OpenText(_path))
            {
                fileText = reader.ReadToEnd();
                var nailExtensions = JsonConvert.DeserializeObject<List<NailCoating>>(fileText);
                nailExtensions.Add(el);
                fileText = JsonConvert.SerializeObject(nailExtensions, Formatting.Indented);
            }
            File.WriteAllText(_path, fileText);
        }

        public void AddNewDesign(Design el)
        {
            var fileText = "";
            using (var reader = File.OpenText(_path))
            {
                fileText = reader.ReadToEnd();
                var nailExtensions = JsonConvert.DeserializeObject<List<Design>>(fileText);
                nailExtensions.Add(el);
                fileText = JsonConvert.SerializeObject(nailExtensions, Formatting.Indented);
            }
            File.WriteAllText(_path, fileText);
        }





        public void DeleteNailExtension(NailExtension nailExtension)
        {
            var fileText = "";
            using (var reader = File.OpenText(_path))
            {
                fileText = reader.ReadToEnd();
                var nailExtensions = JsonConvert.DeserializeObject<List<NailExtension>>(fileText);
                NailExtension nailExtensionToRemove = nailExtensions.Find(n => n.Service == nailExtension.Service);
                nailExtensions.Remove(nailExtensionToRemove);
                fileText = JsonConvert.SerializeObject(nailExtensions, Formatting.Indented);
            }
            File.WriteAllText(_path, fileText);
        }
        public void DeleteManicure(Manicure manicure)
        {
            var fileText = "";
            using (var reader = File.OpenText(_path))
            {
                fileText = reader.ReadToEnd();
                var manicures = JsonConvert.DeserializeObject<List<Manicure>>(fileText);
                Manicure manicureToRemove = manicures.Find(n => n.Service == manicure.Service);
                manicures.Remove(manicureToRemove);
                fileText = JsonConvert.SerializeObject(manicures, Formatting.Indented);
            }
            File.WriteAllText(_path, fileText);
        }
        public void DeleteNailStrengthening(NailStrengthening nailStrengthening)
        {
            var fileText = "";
            using (var reader = File.OpenText(_path))
            {
                fileText = reader.ReadToEnd();
                var nailStrengthenings = JsonConvert.DeserializeObject<List<NailStrengthening>>(fileText);
                NailStrengthening nailStrengtheningToRemove = nailStrengthenings.Find(n => n.Service == nailStrengthening.Service);
                nailStrengthenings.Remove(nailStrengtheningToRemove);
                fileText = JsonConvert.SerializeObject(nailStrengthenings, Formatting.Indented);
            }
            File.WriteAllText(_path, fileText);
        }

        public void DeleteNailCoating(NailCoating nailStrengthening)
        {
            var fileText = "";
            using (var reader = File.OpenText(_path))
            {
                fileText = reader.ReadToEnd();
                var nailStrengthenings = JsonConvert.DeserializeObject<List<NailCoating>>(fileText);
                NailCoating nailStrengtheningToRemove = nailStrengthenings.Find(n => n.Service == nailStrengthening.Service);
                nailStrengthenings.Remove(nailStrengtheningToRemove);
                fileText = JsonConvert.SerializeObject(nailStrengthenings, Formatting.Indented);
            }
            File.WriteAllText(_path, fileText);
        }

        public void DeleteDesign(Design nailStrengthening)
        {
            var fileText = "";
            using (var reader = File.OpenText(_path))
            {
                fileText = reader.ReadToEnd();
                var nailStrengthenings = JsonConvert.DeserializeObject<List<Design>>(fileText);
                Design nailStrengtheningToRemove = nailStrengthenings.Find(n => n.Service == nailStrengthening.Service);
                nailStrengthenings.Remove(nailStrengtheningToRemove);
                fileText = JsonConvert.SerializeObject(nailStrengthenings, Formatting.Indented);
            }
            File.WriteAllText(_path, fileText);
        }

        public List<NailExtension> SortByFiltersNailExtension(string keyWord, string material, string durationDo, double priceDo)
        {

            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                List<NailExtension> nailExtensions =  JsonConvert.DeserializeObject<List<NailExtension>>(fileText);
                if (!string.IsNullOrEmpty(keyWord))
                {
                    nailExtensions = nailExtensions.Where(extension => extension.Service.Contains(keyWord)).ToList();
                }
                if (!string.IsNullOrEmpty(material))
                    nailExtensions = nailExtensions.Where(x => x.Material == material).ToList();
                if (!string.IsNullOrEmpty(durationDo))
                {
                    nailExtensions = nailExtensions.Where(x => Convert.ToInt32(x.Duration.Split(' ')[0]) <= Convert.ToInt32(durationDo.Split(' ')[0])).ToList();
                }
                if(priceDo!=0)
                    nailExtensions = nailExtensions.Where(x => x.Price <= priceDo).ToList();    

                return nailExtensions;

            }

        }
        public List<NailStrengthening> SortByFiltersNailStrengthening(string keyWord, string material, string durationDo, double priceDo)
        {

            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                List<NailStrengthening> nailExtensions = JsonConvert.DeserializeObject<List<NailStrengthening>>(fileText);
                if (!string.IsNullOrEmpty(keyWord))
                {
                    nailExtensions = nailExtensions.Where(extension => extension.Service.Contains(keyWord)).ToList();
                }
                if (!string.IsNullOrEmpty(material))
                    nailExtensions = nailExtensions.Where(x => x.Material == material).ToList();
                if (!string.IsNullOrEmpty(durationDo))
                {
                    nailExtensions = nailExtensions.Where(x => Convert.ToInt32(x.Duration.Split(' ')[0]) <= Convert.ToInt32(durationDo.Split(' ')[0])).ToList();
                }
                if (priceDo != 0)
                    nailExtensions = nailExtensions.Where(x => x.Price <= priceDo).ToList();

                return nailExtensions;

            }

        }
        public List<NailCoating> SortByFiltersNailCoating(string keyWord, string material, string durationDo, double priceDo)
        {

            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                List<NailCoating> nailExtensions = JsonConvert.DeserializeObject<List<NailCoating>>(fileText);
                if (!string.IsNullOrEmpty(keyWord))
                {
                    nailExtensions = nailExtensions.Where(extension => extension.Service.Contains(keyWord)).ToList();
                }
                if (!string.IsNullOrEmpty(material))
                    nailExtensions = nailExtensions.Where(x => x.Material == material).ToList();
                if (!string.IsNullOrEmpty(durationDo))
                {
                    nailExtensions = nailExtensions.Where(x => Convert.ToInt32(x.Duration.Split(' ')[0]) <= Convert.ToInt32(durationDo.Split(' ')[0])).ToList();
                }
                if (priceDo != 0)
                    nailExtensions = nailExtensions.Where(x => x.Price <= priceDo).ToList();

                return nailExtensions;

            }

        }


        public List<Design> SortByFiltersDesign(string keyWord, List<string> selectedColors, string style, double priceDo)
        {

            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                List<Design> nailDesigns = JsonConvert.DeserializeObject<List<Design>>(fileText);
                if (!string.IsNullOrEmpty(keyWord))
                {
                    nailDesigns = nailDesigns.Where(extension => extension.Service.Contains(keyWord)).ToList();
                }
                if (!string.IsNullOrEmpty(style))
                    nailDesigns = nailDesigns.Where(x => x.Style == style).ToList();
                if (selectedColors.Count != 0)
                {
                    nailDesigns = nailDesigns.Where(x => selectedColors.All(color => x.Colors.Contains(color))).ToList();
                }
                if (priceDo != 0)
                    nailDesigns = nailDesigns.Where(x => x.Price <= priceDo).ToList();

                return nailDesigns;

            }

        }
        public void AddToSelectedServices(string service, double price)
        {
            var fileText = "";
            using (var reader = File.OpenText(_path))
            {
                fileText = reader.ReadToEnd();
                var selectedServices = JsonConvert.DeserializeObject<List<SelectedService>>(fileText);
                selectedServices.Add(new SelectedService(service,price));
                fileText = JsonConvert.SerializeObject(selectedServices, Formatting.Indented);
            }
            File.WriteAllText(_path, fileText);
        }

        public List<Manicure> SortByFiltersManicure(string keyWord, string durationDo, double priceDo)
        {

            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                List<Manicure> nailExtensions = JsonConvert.DeserializeObject<List<Manicure>>(fileText);
                if (!string.IsNullOrEmpty(keyWord))
                {
                    nailExtensions = nailExtensions.Where(extension => extension.Service.ToLower().Contains(keyWord.ToLower())).ToList();
                }
                if (!string.IsNullOrEmpty(durationDo))
                {
                    nailExtensions = nailExtensions.Where(x => Convert.ToInt32(x.Duration.Split(' ')[0]) <= Convert.ToInt32(durationDo.Split(' ')[0])).ToList();
                }
                if (priceDo != 0)
                    nailExtensions = nailExtensions.Where(x => x.Price <= priceDo).ToList();

                return nailExtensions;

            }

        }

        public NailExtension ReadANailExtension(string service)
        {
            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<NailExtension>>(fileText).FirstOrDefault(x => x.Service == service);
                
            }
        }
        public Manicure ReadlManicure(string service)
        {
            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject< List<Manicure>>(fileText).FirstOrDefault(x=> x.Service == service);
            }
        }
        public NailStrengthening ReadNailStrengthening(string service)
        {
            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject< List<NailStrengthening>>(fileText).FirstOrDefault(x => x.Service == service);
            }
        }
        public Design ReadDesigns(string service)
        {
            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject< List<Design>>(fileText).FirstOrDefault(x => x.Service == service);
            }
        }
        public NailCoating ReadNailCoaing(string service)
        {
            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject< List<NailCoating>>(fileText).FirstOrDefault(x => x.Service == service);
            }
        }

        public void XMLConverter()
        {
            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                var services =  JsonConvert.DeserializeObject<List<SelectedService>>(fileText);


                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                System.Xml.XmlElement rootElement = xmlDoc.CreateElement("Services");
                xmlDoc.AppendChild(rootElement);

                foreach (SelectedService service in services)
                {
                    System.Xml.XmlElement serviceElement = xmlDoc.CreateElement("Service");

                    System.Xml.XmlElement nameElement = xmlDoc.CreateElement("Name");
                    nameElement.InnerText = service.Service;
                    serviceElement.AppendChild(nameElement);

                    System.Xml.XmlElement priceElement = xmlDoc.CreateElement("Price");
                    priceElement.InnerText = service.Price.ToString();
                    serviceElement.AppendChild(priceElement);

                    rootElement.AppendChild(serviceElement);
                }

                string xmlFilePath = "services.xml";
                xmlDoc.Save(xmlFilePath);
            }
        }

    }
}
