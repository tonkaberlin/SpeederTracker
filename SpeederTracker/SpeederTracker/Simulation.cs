using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeederTracker
{
    class Simulation
    {
        public Simulation()
        {
            //Create a bunch of cars
            Random r = new Random();
            List<Car> cars = new List<Car>();
            for (int i = 0; i < 3; i++)
                cars.Add(new Car(r.Next(0, 1000)));
            cars.Add(new Car(1500));
            //Create a database manager
            DatabaseManager dman = new DatabaseManager();
            //Create a dispatcher
            Dispatcher dispatcher = new Dispatcher(cars, dman);

            //TODO: set the video feed
            VideoFeed f = new VideoFeed(dispatcher, 1400);
            f.AnalyzeVideo(null);
        }
    }
}
