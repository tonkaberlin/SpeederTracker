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
        List<Car> cars = new List<Car>();
        Random r = new Random();
        public Dispatcher()
        {
            for(int i = 0; i < 3; i++)
                cars.Add(new Car(r.Next(0, 1000)));
        }

        public void NotifySpeeder(int cameralocation, double speed, File image)
        {

        }

        public void StoreInDatabase()
        {
            //Call the method to store stuff in the database
        }

        public void NotifyCar(int cameralocation, double speed, File image)
        {
            Car c = cars.OrderBy(x => x.Location - cameralocation).First();
            c.speeder(cameralocation, speed, image);
        }
    }
}
