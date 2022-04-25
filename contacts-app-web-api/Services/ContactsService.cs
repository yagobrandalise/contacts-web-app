using ContactsApplication.Context;
using ContactsApplication.Models;
using ContactsApplication.ViewModels;
using AutoMapper;

namespace ContactsApplication.Services
{
    public class ContactsService
    {
        private ContactsDbContext _context;
        private IMapper _mapper;

        public ContactsService(ContactsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddContact(ContactViewModel contact)
        {
            _context.Add(_mapper.Map<Contact>(contact));
            _context.SaveChanges();
        }

        public IEnumerable<Contact> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
             return _context.Contacts.Where(x => x.Name.Contains(keyword)).ToList();
            
            return _context.Contacts.ToList();
        }

        public Contact Get(long id) => _context.Contacts.SingleOrDefault(p => p.Id == id);

        public Contact Update(long id, ContactViewModel contact)
        {
            var _contact = _context.Contacts.SingleOrDefault(p => p.Id == id);
            if (_contact != null)
            {
                _contact.Update(_mapper.Map<Contact>(contact));
                _context.SaveChanges();
            }
            return _contact;
        }

        public void Delete(long id)
        {
            var contact = _context.Contacts.SingleOrDefault(p => p.Id == id);
            if (contact != null)
            {
                _context.Remove(contact);
                _context.SaveChanges();
            }
        }
    }
}
