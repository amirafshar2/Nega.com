using BE;
using BLL.Abstract;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrate
{
    public class ContactManager : IContactService
    {
        IContactDal _ıcontactdal;

        public ContactManager(IContactDal ıcontactdal)
        {
            _ıcontactdal = ıcontactdal;
        }

        public void Add(Contact t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Contact t)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
