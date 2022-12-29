using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schedule;

internal class ScheduleGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public static ScheduleGroup Create(string name, DateTime startDate, DateTime? endDate)
    {
        return new ScheduleGroup
        {
            Name = name,
            StartDate = startDate,
            EndDate = endDate ?? DateTime.Now.AddYears(30)
        };
    }
}
record DurationTime(TimeSpan StartTime, TimeSpan EndTime)
{
    public int TotalMinutes => (int)(EndTime - StartTime).TotalMinutes;
}

internal abstract class WorkSchedule
{
    protected WorkSchedule(int id, int supllierId, int serviceId, DurationTime durationTime)
    {
        Id = id;
        SupllierId = supllierId;
        ServiceId = serviceId;
        DurationTime = durationTime;
    }

    public int Id { get; set; }
    public int SupllierId { get; set; }
    public int ServiceId { get; set; }
    public DurationTime DurationTime { get; set; }
    public abstract DateTime StartDate { get; }
    public abstract DateTime EndDate { get; }
    public static WorkScheduleRegular CreateRegular(int supllierId, int serviceId, DurationTime durationTime, ScheduleGroup scheduleGroup, DayOfWeek dayOfWeek)
    => new WorkScheduleRegular(0, supllierId, serviceId, durationTime, scheduleGroup, dayOfWeek);
    public WorkScheduleIRRegular CreateIRRegular(int supllierId, int serviceId, DurationTime durationTime, DateTime startDate, bool isOverrideBlock, Recurringrule recurringRule)
    => new WorkScheduleIRRegular(0, supllierId, serviceId, durationTime, startDate, isOverrideBlock, recurringRule);

}
/// <summary>
/// Supplier has a regular business week for a service which has one or more intervals per day
/// </summary>
internal class WorkScheduleRegular : WorkSchedule
{
    internal WorkScheduleRegular(int id, int supllierId, int serviceId, DurationTime durationTime, ScheduleGroup scheduleGroup, DayOfWeek dayOfWeek) : base(id, supllierId, serviceId, durationTime)
    {
        ScheduleGroup = scheduleGroup;
        DayOfWeek = dayOfWeek;
    }
    public ScheduleGroup ScheduleGroup { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public override DateTime StartDate => ScheduleGroup.StartDate;
    public override DateTime EndDate => ScheduleGroup.EndDate;
}
/// <summary>
/// Supplier can define exceptions with regard to Reqular timetable.
/// A specific date
/// An interval with start date and End date
/// Can override Block Times(optional)
/// </summary>
internal class WorkScheduleIRRegular : WorkSchedule
{
    internal WorkScheduleIRRegular(int id, int supllierId, int serviceId, DurationTime durationTime, DateTime startDate, bool isOverrideBlock, Recurringrule recurringRule) : base(id, supllierId, serviceId, durationTime)
    {
        StartDate = startDate;
        IsOverrideBlock = isOverrideBlock;
        RecurringRule = recurringRule;
    }
    public override DateTime StartDate { get; }
    public override DateTime EndDate => RecurringRule.Until;
    public bool IsOverrideBlock { get; set; }
    public Recurringrule RecurringRule { get; set; }
}
internal enum ScheduleType
{
    Regular,
    IRRegular
}
internal class Recurringrule
{
    public Recurringrule(RecurringFrequency frequency, List<DayOfWeek> dayOfWeeks, int repeatEvery, DateTime until)
    {
        Frequency = frequency;
        DayOfWeeks = dayOfWeeks;
        RepeatEvery = repeatEvery;
        Until = until;
    }

    public RecurringFrequency Frequency { get; set; }
    public List<DayOfWeek> DayOfWeeks { get; set; }
    public int RepeatEvery { get; set; }
    public DateTime Until { get; set; }
}
internal enum RecurringFrequency
{
    Daily, WEEKLY, MONTHLY

}
