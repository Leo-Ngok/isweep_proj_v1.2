using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace v1_10.Models
{
    class tTimer1
    {
        private readonly TimeSpan _timeSpan;
        private readonly Action _callback;
        private CancellationTokenSource _cancellation;
        public tTimer1(TimeSpan timespan, Action callback)
        {
            this._timeSpan = timespan;
            this._callback = callback;
            this._cancellation = new CancellationTokenSource();
        }
        public void Start() { var cts = _cancellation;
            Device.StartTimer(_timeSpan, () => {
                if (cts.IsCancellationRequested) return false;
                _callback.Invoke(); return true;
            });
        }
        public void Stop() {
            Interlocked.Exchange(ref _cancellation, new CancellationTokenSource()).Cancel();
        }
    }
}
