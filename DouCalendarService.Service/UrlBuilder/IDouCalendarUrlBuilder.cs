namespace DouCalendarService.Service.UrlBuilder
{
    public interface IDouCalendarUrlBuilder
    {
        IDouCalendarUrlBuilder AddCity(string city);

        IDouCalendarUrlBuilder AddTag(string tag);

        IDouCalendarUrlBuilder AddDay(string day);

        IDouCalendarUrlBuilder AddTagWithCity(string city, string tag);

        string Build();
    }
}
