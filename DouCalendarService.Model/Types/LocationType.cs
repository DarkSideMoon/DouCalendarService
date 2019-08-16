using System.Runtime.Serialization;

namespace DouCalendarService.Model.Types
{
    public enum LocationType
    {
        [EnumMember(Value = "Киев")]
        Kyiv = 1,

        [EnumMember(Value = "Винница")]
        Vinnytsia = 2,
        
        [EnumMember(Value = "Днепр")]
        Dnipro = 3,

        [EnumMember(Value = "Житомир")]
        Zhytomyr = 4,

        [EnumMember(Value = "Запорожье")]
        Zaporizhzhia = 5,

        [EnumMember(Value = "Ивано-Франковск")]
        IvanoFrankivsk = 6,

        [EnumMember(Value = "Луцк")]
        Lutsk = 7,

        [EnumMember(Value = "Львов")]
        Lviv = 8,

        [EnumMember(Value = "Николаев")]
        Mykolayiv = 9,

        [EnumMember(Value = "Одесса")]
        Odessa = 10,

        [EnumMember(Value = "Ровно")]
        Rivne = 11,

        [EnumMember(Value = "Харьков")]
        Kharkiv = 12,

        [EnumMember(Value = "Херсон")]
        Kherson = 13,

        [EnumMember(Value = "Черкассы")]
        Cherkasy = 14,

        [EnumMember(Value = "Черновцы")]
        Chernivtsi = 15,

        [EnumMember(Value = "online")]
        Online = 16,

        [EnumMember(Value = "Рига")]
        Riga = 17,

        [EnumMember(Value = "Минск")]
        Minsk = 18,

        [EnumMember(Value = "Варшава")]
        Warsaw = 19
    }
}
