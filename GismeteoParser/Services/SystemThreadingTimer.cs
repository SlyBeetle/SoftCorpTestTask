using System.Threading;
using GismeteoParserConsoleApplication.Infrastructure;

namespace GismeteoParserConsoleApplication.Services
{
    class SystemThreadingTimer : ITimer
    {
        private readonly TimerCallback _timerCallback;
        private Timer _timer;

        public SystemThreadingTimer(TimerCallback timerCallback)
        {
            _timerCallback = timerCallback;
        }

        public void Start(int interval)
        {
            _timer = new Timer(_timerCallback, null, 0, interval);
        }
    }
}
