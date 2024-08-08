using DAL.Context;
using System;
using System.Linq;

namespace Negacom.Service
{
    public class VisitorCounterService
    {
        private readonly DB _context;

        public VisitorCounterService(DB context)
        {
            _context = context;
            InitializeVisitorCount();
        }

        private void InitializeVisitorCount()
        {
            var today = DateTime.Today;
            if (!_context.visitorCounts.Any(vc => vc.visitdate == today))
            {
                _context.visitorCounts.Add(new BE.VisitorCount { count = 0, visitdate = today });
                _context.SaveChanges();
            }
        }

        public void IncrementCounter()
        {
            var today = DateTime.Today;
            var visitorCount = _context.visitorCounts.First(vc => vc.visitdate == today);
            visitorCount.count++;
            _context.SaveChanges();
        }

        public int GetVisitorCount()
        {
            var today = DateTime.Today;
            var visitorCount = _context.visitorCounts.FirstOrDefault(vc => vc.visitdate == today);
            return visitorCount?.count ?? 0;
        }

        public int GetVisitorCountByDate(DateTime date)
        {
            var visitorCount = _context.visitorCounts.FirstOrDefault(vc => vc.visitdate == date);
            return visitorCount?.count ?? 0;
        }

    }
}

