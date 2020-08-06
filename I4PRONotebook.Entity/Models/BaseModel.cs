using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace I4PRONotebook.Entity.Models
{
    public class BaseModel
    {
        [DataMember]
        public int ID { get; set; }
    }
}
