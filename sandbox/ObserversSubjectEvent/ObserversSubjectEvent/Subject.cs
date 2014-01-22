/* author: Loic Damien
 * description: a very simple exemple to demonstrate the use of event
 * date: 2014-01-19
 */
using System;

namespace ObserversSubjectEvent
{

    public class OnRateChangedArgs : EventArgs
    {
        public OnRateChangedArgs(Double oldRate, Double newRate)
        {
            OldRate = oldRate;
            NewRate = newRate;
        }
        public Double OldRate { get; private set; } // readonly
        public Double NewRate { get; private set; } // readonly
    }

    public class Subject
    {
        public delegate void OnRateChangedEventHandler(object sender, OnRateChangedArgs e);

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
                        handler(this, new OnRateChangedArgs(oldRate, _rate));
                    }
                }
            }
        }
    }
}
