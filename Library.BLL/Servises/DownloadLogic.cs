using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Library.BLL.Interfaces;
using Library.Entities.Models;
namespace Library.BLL.Servises
{
  public  class DownloadLogic : IDownloadLogic
    {
        string Path { get; set; }
        public DownloadLogic()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Path = System.IO.Path.GetDirectoryName(location);
        }

        public void Download(Book book)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Book));

            using (FileStream fs = new FileStream(String.Format(Path, book.Name), FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, book);
            }

        }
        public void Download(Magazine magazine)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Magazine));

     
            using (FileStream fs = new FileStream(String.Format(Path, magazine.Name), FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, magazine);
            }
        }
        public void Download(Brochure brochure)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Brochure));

           
            using (FileStream fs = new FileStream(String.Format(Path, brochure.Name), FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, brochure);
            }
        }
    }
}
