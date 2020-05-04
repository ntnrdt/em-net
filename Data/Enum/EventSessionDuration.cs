using System.ComponentModel;

namespace MeetApp.Data.Enum
{
   public enum EventSessionDuration
    {
        [Description("Half Hour")]
        HalfHour = 1,
        [Description("1 Hour")]
        OneHour = 2,
        [Description("Half Day")]
        HalfDay = 3,
        [Description("Full Day")]
        FullDay = 4
    }
}