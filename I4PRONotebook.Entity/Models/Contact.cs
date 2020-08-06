using System;
using System.Collections;
using System.Collections.Generic;

namespace I4PRONotebook.Entity.Models
{
    public class Contact : BaseModel
    {
        public Contact() { }
        public Contact(int id) 
        {
            base.ID = id;
        }
        public string Name { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
