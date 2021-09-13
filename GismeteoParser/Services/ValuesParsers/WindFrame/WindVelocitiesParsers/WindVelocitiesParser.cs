using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.WindFrame.WindVelocitiesParsers
{
    internal abstract class WindVelocitiesParser : ValuesParser<WeatherForecast>
    {
        protected IList<int?> GetWindVelocities(HtmlNode frame, string widgetClasses) =>
            frame.SelectNodes($".//div[@class=\"{widgetClasses}\"]//span[@class=\"unit unit_wind_m_s\"]")
            .Select(node =>
            {
                int? ultravioletIndex = null;
                if (int.TryParse(node.InnerText.Trim(), out int ui))
                {
                    ultravioletIndex = ui;
                }
                return ultravioletIndex;
            })
            .ToArray();
    }
}
