using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpeederTracker
{
    class Dispatcher
    {
        List<Car> cars;
        DatabaseManager dman;
        public Dispatcher(List<Car> c, DatabaseManager d)
        {
            cars = c;
            dman = d;
        }

        public void NotifySpeeder(int cameralocation, double speed)
        {
            //Send to database
            dman.submitToDatabase(cameralocation, speed);
            
            //Send to car
            Car c = cars.OrderBy(x => x.Location - cameralocation).First();
            c.speeder(cameralocation, speed);
        }
    }
}
