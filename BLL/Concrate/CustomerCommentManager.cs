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
    public class CustomerCommentManager : ICustomerCommentService
    {
        ICustomerCommentDAL _customercomment;

        public CustomerCommentManager(ICustomerCommentDAL customercomment)
        {
            _customercomment = customercomment;
        }

        public void Add(CustomerComment t)
        {
            _customercomment.Add(t);
        }

        public void Delete(CustomerComment t)
        {
            _customercomment.Delete(t);
        }

        public List<CustomerComment> GetAll()
        {
            return _customercomment.GetAll();
        }

        public CustomerComment GetById(int id)
        {
           return _customercomment.GetBayId(id);
        }

        public void Update(CustomerComment t)
        {
            _customercomment.Update(t);
        }
    }
}
