/* author: Loic Damien
 * description: a very simple exemple to demonstrate the use of event.
 *              this a slightly modified version of the code provided for the exercide by C. Maréchal.
 * date: 2014-01-19
 */
using System;

namespace ObserversSubjectEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();

            Observer observer1 = new Observer(1);
            Console.WriteLine("Subscribe observer 1.");
            subject.OnRateChanged += observer1.Notify;

            Observer observer2 = new Observer(2);
            Console.WriteLine("Subscribe observer 2.");
            subject.OnRateChanged += observer2.Notify;

            Observer observer3 = new Observer(3);
            Console.WriteLine("Subscribe observer 3.");
            subject.OnRateChanged += observer2.Notify;
            Observer observer666 = new Observer(666); //le diable
            Console.WriteLine("Subscribe observer 666.");
            subject.OnRateChanged += observer3.Notify;

            Console.WriteLine("\nChange the rate field of the subject.");
            subject.Rate += .5;

            Console.WriteLine("\nUnsubscribe observer1.");
            Console.WriteLine("\nChange the rate field of the subject.");
            subject.OnRateChanged -= observer1.Notify;
            subject.Rate += .5;
        }
    }
}
