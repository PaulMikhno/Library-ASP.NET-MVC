using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ViewEntities.Models
{
    [DataContract]
    public class BookViewModel
    { 
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string YearOfPublishing { get; set; }

        public  List<PublicHouseViewModel> PublicHouses { get; set; }

        public BookViewModel()
        {
            PublicHouses = new List<PublicHouseViewModel>();
        }

    }
}