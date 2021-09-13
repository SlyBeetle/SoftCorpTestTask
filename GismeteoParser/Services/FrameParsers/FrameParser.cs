using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.FrameParsers
{
    internal abstract class FrameParser : IFrameParser<WeatherForecast>
    {
        protected readonly ICollection<IValuesParser<WeatherForecast>> _valuesParsers;
        protected HtmlNode _frame;

        protected FrameParser(ICollection<IValuesParser<WeatherForecast>> valuesParsers)
        {
            _valuesParsers = valuesParsers;
        }

        public abstract void Parse(HtmlDocument page, IList<WeatherForecast> weatherForecastForTenDays);

        protected void ExecuteValuesParsers(IList<WeatherForecast> weatherForecastForTenDays) =>
            _valuesParsers.AsParallel().ForAll(valuesParser => valuesParser.Parse(_frame, weatherForecastForTenDays));

        // Starting from one
        protected void SetFrameByIndexNumber(HtmlDocument page, int indexNumber)
        {
            HtmlNode smFrame = page.DocumentNode.SelectSingleNode("//div[@class=\"__frame_sm\"]");
            // In Browser: randomSubframe = smFrame.SelectSingleNode("./div[@class=\"wrap_small __frame\"]");
            HtmlNode randomSubframe =
                smFrame.SelectSingleNode("./div[@class=\"__frame\"]/a[@class=\"block nolink black trigger trigger_tire trigger_tire_winter clearfix\"]");
            if (randomSubframe != null)                
            {
                const int RANDOM_SUBFRAME_INDEX = 4; // Text nodes are among child nodes.
                HtmlNode randomSubframeInChildNodesByIndex = smFrame.ChildNodes[RANDOM_SUBFRAME_INDEX];
                smFrame.RemoveChild(randomSubframeInChildNodesByIndex);
            }
            _frame = smFrame.SelectSingleNode(GetFrameXPathByIndexNumber(indexNumber));
        }

        // Starting from one
        private string GetFrameXPathByIndexNumber(int indexNumber) => $"./div[{indexNumber}]";
    }
}
