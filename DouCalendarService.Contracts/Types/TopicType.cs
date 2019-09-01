using System.Runtime.Serialization;

namespace DouCalendarService.Contracts.Types
{
    public enum TopicType
    {
        [EnumMember(Value = ".Net")]
        Net = 1,

        [EnumMember(Value = "Agile")]
        Agile = 2,

        [EnumMember(Value = "AI")]
        AI = 3,

        [EnumMember(Value = "Android")]
        Android = 4,

        [EnumMember(Value = "big data")]
        BigData = 5,

        [EnumMember(Value = "Blockchain")]
        Blockchain = 6,

        [EnumMember(Value = "C")]
        C = 7,

        [EnumMember(Value = "C++")]
        CPlusPlus = 8,

        [EnumMember(Value = "cloud")]
        Cloud = 9,

        [EnumMember(Value = "Data Science")]
        DataScience = 10,

        [EnumMember(Value = "Database")]
        Database = 11,

        [EnumMember(Value = "DevOps")]
        DevOps = 12,
    }
}
