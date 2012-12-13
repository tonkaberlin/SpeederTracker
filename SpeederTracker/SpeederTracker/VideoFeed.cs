using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpeederTracker
{
    class VideoFeed
    {
        public int Location;
        public Dispatcher dispatcher;

        public VideoFeed(Dispatcher d, int location)
        {
            Location = location;
            dispatcher = d;
        }

        public void AnalyzeVideo()
        {
            //Take the video and look for speeders. 
            //Notify the dispatcher for a speeder (method NotifySpeeder)
        }
    }
}
