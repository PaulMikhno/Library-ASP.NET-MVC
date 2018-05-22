using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace Library.Entities.Models
{
    [DataContract]
    public class PublicHouse: BaseModel
    {
        //[DataMember]
        //public int Id { get; set; }
        //[DataMember]
        //public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Book> Books { get; set; }

        
        public PublicHouse()
        {
            Books = new List<Book>();
        }

    }
}
