namespace Domain.Utils;
public static partial class DateTimeHelper
{
    public static DateTime SetTimeZone(this DateTime dateTime, TimeZoneEnum timeZone)
    {
        var timeZoneDescription = timeZone.GetDescription();

        return TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timeZoneDescription));
    }
}