using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schedule
{
    /// <summary>
    /// a specific date or an interval which the supplier is not available. (independent from Service, just defined for Supplier)
    /// </summary>
    internal class BlockTime
    {
        public BlockTime(int id, int supplierId, string reason, DateTime date, DurationTime? durationTime)
        {
            Id = id;
            Reason = reason;
            Date = date;
            DurationTime = durationTime;
            SupplierId = supplierId;
        }

        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public DurationTime? DurationTime { get; set; }

        public static BlockTime CreateDate(int supplierId, DateTime date, string reason)
            => new BlockTime(0, supplierId, reason, date, null);
        public static BlockTime CreateTimeOfDate(int supplierId, DateTime date, string reason, DurationTime durationTime)
            => new BlockTime(0, supplierId, reason, date, durationTime);
    }
}
