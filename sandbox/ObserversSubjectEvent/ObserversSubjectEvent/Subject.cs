/* author: Loic Damien
 * description: a very simple exemple to demonstrate the use of event
 * date: 2014-01-19
 */
using System;

namespace ObserversSubjectEvent
{

    public class OnRateChangedtArgs : EventArgs
    {
        public OnRateChangedtArgs(Double oldRate, Double newRate)
        {
            OldRate = oldRate;
            NewRate = newRate;
        }
        public Double OldRate { get; private set; } // readonly
        public Double NewRate { get; private set; } // readonly
    }

    public class Subject
    {
        public delegate void OnRateChangedEventHandler(object sender, OnRateChangedtArgs e);

        Double _rate;
        public event OnRateChangedEventHandler OnRateChanged;

        public Double Rate
        {
            get { return _rate; }
            set
            {
                if (_rate != value)
                {
                    Double oldRate = _rate;
                    _rate = value;
                    OnRateChangedEventHandler handler = OnRateChanged;
                    if (handler != null)
                    {
                        handler(this, new OnRateChangedtArgs(oldRate, _rate));
                    }
                }
            }
        }
    }
}
