namespace ContactsApplication.Models
{
    public class Contact
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private  set; }
        public string PhoneNumber { get; private set; }
        public string Whatsapp { get; private set; }
        public byte[] PictureContent { get; private set; }

        public void Update(Contact contact)
        {
            Name = contact.Name;
            Email = contact.Email;
            PhoneNumber = contact.PhoneNumber;
            Whatsapp = contact.Whatsapp;
            PictureContent = contact.PictureContent;
        }
    }
}
