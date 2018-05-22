using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace Library.Entities.Models
{
    [DataContract]
    public class Book: BaseModel
    {
        //[DataMember]
        //public int Id { get; set; }
        //[DataMember]
        //public string Name { get; set; }
        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string YearOfPublishing { get; set; }

        public virtual List<PublicHouse> PublicHouses { get; set; }

        public Book()
        {
            PublicHouses = new List<PublicHouse>();
        }

    }
}