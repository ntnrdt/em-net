using System.ComponentModel;

namespace MeetApp.Data.Enum
{
   public enum EventType
    {
        [Description("Meeting")]
        Meeting = 1,
        [Description("Reminder")]
        Reminder = 2,
        [Description("Task")]
        Task = 3
    }
}