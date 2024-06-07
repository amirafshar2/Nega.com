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
            _ıcontactdal.Add(t);
        }

        public void Delete(Contact t)
        {
           _ıcontactdal.Delete(t);
        }

        public List<Contact> GetAll()
        {
            return _ıcontactdal.GetAll();
        }

        public Contact GetById(int id)
        {
            return _ıcontactdal.GetBayId(id);
        }

        public void Update(Contact t)
        {
            _ıcontactdal.Update(t);
        }
    }
}
