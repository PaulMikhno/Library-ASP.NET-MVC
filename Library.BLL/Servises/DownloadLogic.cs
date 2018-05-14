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
        public void Download(Book book)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Book));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(String.Format("C:\\Users\\Anuitex-100\\Desktop\\{0}.xml", book.Name), FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, book);
            }

        }
        public void Download(Magazine magazine)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Magazine));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(String.Format("C:\\Users\\Anuitex-100\\Desktop\\{0}.xml", magazine.Name), FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, magazine);
            }
        }
        public void Download(Brochure brochure)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Brochure));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(String.Format("C:\\Users\\Anuitex-100\\Desktop\\{0}.xml", brochure.Name), FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, brochure);
            }
        }
    }
}
