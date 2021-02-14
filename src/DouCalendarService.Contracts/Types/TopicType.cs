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

        [EnumMember(Value = "Front-end")]
        FrontEnd = 13,

        [EnumMember(Value = "gamedev")]
        GameDev = 14,

        [EnumMember(Value = "hardware")]
        HardWare = 15,

        [EnumMember(Value = "highload")]
        Highload = 16,

        [EnumMember(Value = "HR")]
        Hr = 17,

        [EnumMember(Value = "iOS")]
        Ios = 18,

        [EnumMember(Value = "IoT")]
        Iot = 19,

        [EnumMember(Value = "Java")]
        Java = 20,

        [EnumMember(Value = "JavaScript")]
        JavaScript = 21,

        [EnumMember(Value = "Linux")]
        Linux = 22,

        [EnumMember(Value = "PHP")]
        PHP = 23,

        [EnumMember(Value = "Python")]
        Python = 24,

        [EnumMember(Value = "QA")]
        QA = 25,

        [EnumMember(Value = "Scala")]
        Scala = 26,

        [EnumMember(Value = "Scrum")]
        Scrum = 27,

        [EnumMember(Value = "Solution Architecture")]
        SolutionArchitecture = 28,

        [EnumMember(Value = "конференция")]
        Conference = 29,

        [EnumMember(Value = "курсы")]
        Course = 30,

        [EnumMember(Value = "менеджмент")]
        Management = 31,

        [EnumMember(Value = "митап")]
        Mitap = 32,

        [EnumMember(Value = "вебинар")]
        Webinar = 33,

        [EnumMember(Value = "хакатон")]
        Hackathon = 34,

        [EnumMember(Value = "английский")]
        English = 35
    }
}
