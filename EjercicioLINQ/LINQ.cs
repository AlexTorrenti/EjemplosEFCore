using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    public class LINQ
    {
        class Voice
        {
            public int Downloads { get; set; }
            public double Rating { get; set; }
            public string Name { get; set; }
            public double Version { get; set; }

            public Voice(string name, int downloads, double version, double rating)
            {
                Name = name;
                Downloads = downloads;
                Version = version;
                Rating = rating;
            }

            public override string ToString()
            {
                return string.Format("{0} - downloads: {1}", Name, Downloads);
            }
        }

        class PopularVoice
        {
            public string Name { get; set; }
            public double Version { get; set; }

            public override string ToString()
            {
                 
                return string.Format("{0} - version: {1}", Name, Version);
            }
        
        }

        public LINQ()
        {
            List<Voice> voiceList = new List<Voice>();

            voiceList.Add(new Voice("Robot", 1000, 1.0, 4.4));
            voiceList.Add(new Voice("Kong", 500, 2.0, 3.4));
            voiceList.Add(new Voice("Zombie", 3000, 1.0, 5.0));
            voiceList.Add(new Voice("Alien", 1500, 1.0, 3.5));
            voiceList.Add(new Voice("UnderWater", 1200, 2.0, 1.5));
            voiceList.Add(new Voice("Franky", 700, 1.0, 4.4));
            voiceList.Add(new Voice("Android", 550, 1.0, 5.0));
            voiceList.Add(new Voice("Dark", 900, 2.0, 2.4));
            voiceList.Add(new Voice("Echo", 1200, 2.0, 3.4));
            voiceList.Add(new Voice("Fan", 3000, 3.0, 4.0));
            voiceList.Add(new Voice("Chipmunk", 1150, 3.0, 4.0));


            var query = from Voice voice in voiceList
                        where voice.Downloads > 1000
                        orderby voice.Downloads descending
                        select voice;
                                                           
            Console.WriteLine("Voices over 1000 ordered descending");

            foreach (Voice v in query)
                Console.WriteLine(v);



            var allVoices = from Voice voice in voiceList select (Downloads: voice.Downloads, Name: voice.Name);
            Console.WriteLine(string.Format(">1000:{0:0.00} vs all:{1:0.00}", query.Average(x => x.Downloads), allVoices.Average(x => x.Downloads)));
            Console.WriteLine("Total Downloads: {0}", allVoices.Sum(x => x.Downloads));


            var groupedVoices = from Voice voice in voiceList
                                group voice by voice.Version;

            foreach (var groupVoice in groupedVoices)
            {
                Console.WriteLine(string.Format("{0:0.0}", groupVoice.Key));

                foreach (Voice voice in groupVoice.OrderByDescending(x => x.Downloads))
                {
                    Console.WriteLine("\t{0}", voice);
                }
            }

            var groupedVoices2 = from Voice voice in voiceList
                                group voice by voice.Name[0] into groupedVoice
                                orderby groupedVoice.Key
                                select groupedVoice;

            foreach (var groupVoice in groupedVoices2)
            {
                Console.WriteLine(string.Format("{0:0.0}", groupVoice.Key));

                foreach (Voice voice in groupVoice.OrderByDescending(x => x.Downloads))
                {
                    Console.WriteLine("\t{0}", voice);
                }
            }

            var popularVoices = from Voice voice in voiceList
                                let popularFactor = voice.Rating * voice.Downloads
                                where (popularFactor >= allVoices.Average(x => x.Downloads * 2.5) * 1.2)
                                orderby voice.Downloads descending
                                select new PopularVoice { Name = voice.Name, Version = voice.Version };

            Console.WriteLine("Popular Voices");
            foreach (var popularVoice in popularVoices)
                Console.WriteLine(popularVoice);
                         
        }
    }
}
