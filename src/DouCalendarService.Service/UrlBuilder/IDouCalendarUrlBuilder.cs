﻿namespace DouCalendarService.Service.UrlBuilder
{
    public interface IDouCalendarUrlBuilder
    {
        IDouCalendarUrlBuilder AddId(string id);

        IDouCalendarUrlBuilder AddCity(string city);

        IDouCalendarUrlBuilder AddTag(string tag);

        IDouCalendarUrlBuilder AddDay(string day);

        IDouCalendarUrlBuilder AddPage(string page);

        IDouCalendarUrlBuilder AddTagWithCity(string city, string tag);

        string Build();
    }
}
