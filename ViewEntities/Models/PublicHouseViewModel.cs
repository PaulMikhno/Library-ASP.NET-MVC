using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ViewEntities.Models
{
    [DataContract]
    public class PublicHouseViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }

        //[IgnoreDataMember]
        //public  ICollection<BookViewModel> Books { get; set; }


        public PublicHouseViewModel()
        {
            //Books = new List<BookViewModel>();
        }

    }
}