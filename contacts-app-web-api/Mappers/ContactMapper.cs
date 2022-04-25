using AutoMapper;
using ContactsApplication.Models;
using ContactsApplication.ViewModels;

namespace ContactsApplication.Mappers
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<Contact, ContactViewModel>();
            CreateMap<ContactViewModel, Contact>();
        }
    }
}
