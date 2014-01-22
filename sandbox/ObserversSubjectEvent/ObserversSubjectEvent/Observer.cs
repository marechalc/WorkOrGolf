/* author: Loic Damien
 * description: a very simple exemple to demonstrate the use of event
 * date: 2014-01-19
 */
using System;

namespace ObserversSubjectEvent
{
    class Observer
    {

        public int Id { get; set; }

        public Observer(int id)
        {
            Id = id;
        }

        public void Notify(object sender, EventArgs e)
        {
            Console.WriteLine("Observer {0} has received a notification.", Id);
          // Console.WriteLine("Observer {0} has received a notification. Old_rate = {1}, New_rate={2}", Id, e.OldRate, e.NewRate);
        }
    }
}
