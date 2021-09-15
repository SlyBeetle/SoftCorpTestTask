using System.Collections.Generic;
using GismeteoCore.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.WindFrame.WindVelocitiesParsers
{
    internal abstract class WindVelocitiesParser : ValuesParser<WeatherForecast>
    {
        protected IList<int?> GetWindVelocities(HtmlNode frame, string widgetClasses) =>
            GetNullableIntegers(frame, $".//div[@class=\"{widgetClasses}\"]//span[@class=\"unit unit_wind_m_s\"]");
    }
}
