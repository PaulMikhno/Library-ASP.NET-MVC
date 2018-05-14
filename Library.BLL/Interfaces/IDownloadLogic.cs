using System;
using System.Collections.Generic;
using System.Text;
using Library.Entities.Models;

namespace Library.BLL.Interfaces
{
    public interface IDownloadLogic
    {
        void Download(Book book);
        void Download(Magazine magazine);
        void Download(Brochure magazine);
    }
}

