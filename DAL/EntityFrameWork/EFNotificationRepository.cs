using BE;
using DAL.Abstract;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFrameWork
{
    public class EFNotificationRepository : GenericRepository<Notification> , INotificationDAL
    {
    }
}
