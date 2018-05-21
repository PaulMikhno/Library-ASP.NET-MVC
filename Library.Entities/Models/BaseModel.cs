using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.Models
{
    [DataContract]
    public class BaseModel
    {
      [DataMember]
      public int Id { get; set; }

      [DataMember]
      public string Name { get; set; }

    }
}
