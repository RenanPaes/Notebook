using System;
using System.Text.Json.Serialization;

namespace I4PRONotebook.Entity.Models
{
    public class Email : BaseModel
    {
        public string EmailName { get; set; }
        
        [JsonIgnore]
        public virtual Contact Contact { get; set; }
    }
}
