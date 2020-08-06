using I4PRONotebook.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I4ProNotebook.Web.Models
{
    public class NotepadModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<Email> Emails { get; set; }
        public List<int> EmailRemoveIds { get; set; }
        public List<int> PhoneNumberRemoveIds { get; set; }

        public void RemoveEmails(Models.AppContext context)
        {
            try
            {
                if (EmailRemoveIds != null)
                {
                    foreach (var id in EmailRemoveIds)
                    {
                        var email = context.Set<Email>().FirstOrDefault(e => e.ID == id);
                        context.Set<Email>().Remove(email);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }            
        }

        public void RemovePhoneNumbers(Models.AppContext context)
        {
            try
            {
                if (PhoneNumberRemoveIds != null)
                {
                    foreach (var id in PhoneNumberRemoveIds)
                    {
                        var phoneNumber = context.Set<PhoneNumber>().FirstOrDefault(e => e.ID == id);
                        context.Set<PhoneNumber>().Remove(phoneNumber);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Email> GetEmails(Contact contact, Models.AppContext context)
        {
            try
            {
                List<Email> emails = new List<Email>();

                if (Emails != null)
                {
                    foreach (Email email in Emails)
                    {
                        var entityEmail = context.Set<Email>().FirstOrDefault(e => e.ID == email.ID);

                        if (entityEmail == null)
                        {
                            emails.Add(new Email()
                            {
                                EmailName = email.EmailName,
                                Contact = contact
                            });
                        }
                    }
                }

                return emails;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<PhoneNumber> GetPhoneNumbers(Contact contact, Models.AppContext context)
        {
            try
            {
                List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
                
                if (PhoneNumbers != null)
                {
                    foreach (PhoneNumber phoneNumber in PhoneNumbers)
                    {
                        var entityPhoneNumber = context.Set<PhoneNumber>().FirstOrDefault(e => e.ID == phoneNumber.ID);
                        
                        if (entityPhoneNumber == null)
                        {
                            phoneNumbers.Add(new PhoneNumber()
                            {
                                Number = phoneNumber.Number,
                                Contact = contact
                            });
                        }
                    }
                }

                return phoneNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
