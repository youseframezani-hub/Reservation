using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schedule
{
    internal class BlockTime
    {
        public BlockTime(int id, string reason, DateTime date, DurationTime? durationTime)
        {
            Id = id;
            Reason = reason;
            Date = date;
            DurationTime = durationTime;
        }

        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public DurationTime? DurationTime { get; set; }

        public static BlockTime CreateDate(DateTime date, string reason)
            => new BlockTime(0, reason, date, null);
        public static BlockTime CreateTimeOfDate(DateTime date, string reason, DurationTime durationTime)
            => new BlockTime(0, reason, date, durationTime);
    }
}
