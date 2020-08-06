using System;
using System.Text.Json.Serialization;

namespace I4PRONotebook.Entity.Models
{
    public class PhoneNumber : BaseModel
    {
        public PhoneNumber()
        {
        }

        public PhoneNumber(int id)
        {
            base.ID = id;
        }

        public string Number { get; set; }

        [JsonIgnore]
        public virtual Contact Contact { get; set; }
    }
}
