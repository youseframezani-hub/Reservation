using Domain.Supplier;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Reservation.Core;

public class Service
{
    public Service(GuidId id, string title, string? description, TimeSpan duration, TimeInterval? timeInterval, int capacity, int priority, Currency price, bool isActive, bool isInternal, List<SupplierServiceConfig>? supplierConfigs)
    {
        Id = id;
        Title = title;
        Description = description;
        Duration = duration;
        TimeInterval = timeInterval;
        Capacity = capacity;
        Priority = priority;
        Price = price;
        _isActive = isActive;
        _isInternal = isInternal;
        _supplierConfigs = supplierConfigs;
    }
    public GuidId Id { get; init; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public TimeSpan Duration { get; private set; }
    public TimeInterval? TimeInterval { get; private set; }
    public int Capacity { get; private set; }
    public int Priority { get; private set; }
    public Currency Price { get; private set; }
    private bool _isInternal;
    private bool _isActive;
    private List<SupplierServiceConfig>? _supplierConfigs;

    public static Service Create(string title, string? description, Currency price, TimeSpan duration, int capacity, int priority, bool isActive, bool isInternal)
    {
        return new Service(GuidId.Create(), title ?? throw new ArgumentNullException(nameof(title)), description,
            duration, null, capacity != 0 ? capacity : throw new ArgumentNullException(nameof(price)), priority, price ?? throw new ArgumentNullException(nameof(price)), isActive, isInternal, null);
    }
    public static Service Create(string title)
    {
        return Create(title, null, Currency.Default, TimeSpan.FromHours(1), 1, 1, true, false);
    }
    public static Service Create(string title, string description) =>
        Create(title, description, Currency.Default, TimeSpan.FromHours(1), 1, 1, true, false);

    public void Update(string title, string description, Currency price, TimeSpan duration, int capacity)
    {
        Title = title;
        Description = description;
        Price = price;
        Duration = duration;
        Capacity = capacity;
    }
    public void SetTimeInterval(TimeInterval timeInterval)
    {
        TimeInterval = timeInterval;
    }
    public void SetPriority(int priority)
    {
        Priority = priority;
    }
    public bool IsActive(GuidId? supplierId = null)
    {
        if (DeActivetedForOrganization())
            return false;

        var supplierConfig = _supplierConfigs?.FirstOrDefault(s => s.SupplierId == supplierId);
        if (supplierConfig == null)
            return true;

        return supplierConfig.IsActive;

        bool DeActivetedForOrganization() => _isActive == false;
    }
    public bool IsInternal(GuidId? supplierId = null)
    {
        if (IsInternalForOrganization())
            return true;

        var supplierConfig = _supplierConfigs?.FirstOrDefault(s => s.SupplierId == supplierId);
        if (supplierConfig == null)
            return false;

        return supplierConfig.IsInternal;

        bool IsInternalForOrganization() => _isInternal == true;
    }
    public void SetActive(bool value) => _isActive = value;
    public void SetActive(GuidId supplierId, bool value)
    {
        var oldConfig = _supplierConfigs?.FirstOrDefault(s => s.SupplierId == supplierId);
        var newConfig = oldConfig == null ? new SupplierServiceConfig(supplierId, value, _isInternal) : oldConfig with { IsActive = value };

        SetSupplierConfig(newConfig);
    }
    public void SetInternal(bool value) => _isInternal = value;
    public void SetInternal(GuidId supplierId, bool value)
    {
        var oldConfig = _supplierConfigs?.FirstOrDefault(s => s.SupplierId == supplierId);
        var newConfig = oldConfig == null ? new SupplierServiceConfig(supplierId, _isActive, value) : oldConfig with { IsInternal = value };

        SetSupplierConfig(newConfig);
    }
    private void SetSupplierConfig(SupplierServiceConfig newConfig)
    {
        if (_supplierConfigs == null)
            _supplierConfigs = new List<SupplierServiceConfig>();
        _supplierConfigs.Add(newConfig);
    }
}

public class TimeInterval
{
    public SlotType SlotType { get; set; }
    public string SlotValue { get; set; }
}

public class Currency
{
    public string Name { get; init; }
    public static Currency Default = new Currency("USD");
    public Currency(string name)
    {
        Name = name;
    }
}

public record SupplierServiceConfig(GuidId SupplierId, bool IsActive, bool IsInternal);

public enum SlotType
{
    /// <summary>
    /// Set time intervals as per business level settings
    /// </summary>
    Default,
    /// <summary>
    /// For example: If you provide consultation from 10 AM to 6 PM then selecting 15 minutes will show 10:00, 10:15, 10:30 ... to... 5:45 and 30 minutes will show 10:00, 10:30, 11:00 ...to... 5:30
    /// </summary>
    Fixed,
    /// <summary>
    /// You can also open certain time slots only after previous slots have been booked by using the hash (#) operator. For example - 9:00 AM, 12:00 PM # 3:00 PM will only open the 3:00 PM slot after both 9:00 AM and 12:00 PM have been booked
    /// </summary>
    Precision
}

