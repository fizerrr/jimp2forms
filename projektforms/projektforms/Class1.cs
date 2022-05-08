using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektforms
{
    class dvd
    {
        String title;
        String direction;
        String type;
        String music;
        String date_of_production;
        String time;

        public dvd(string title, string direction, string type, string music, string date_of_production, string time)
        {
            this.title = title;
            this.direction = direction;
            this.type = type;
            this.music = music;
            this.date_of_production = date_of_production;
            this.time = time;
        }

        public dvd()
        {
        }

        public override string ToString()
        {
            return "|" + "Title: " + title + "|" + "Reżyseria: " + direction + "|" + "Gatunek: " +
                type + "|" + "Muzyka: " + music + "|" +
              "Data premiery: " + date_of_production + "|" + "Czas trwania: " + time + "|";
        }

        public string savetext()
        {
            return title + "\n" + direction + "\n" + type + "\n" + music + "\n" + date_of_production + "\n" + time;
        }


        public string return_title()
        {
            return title;
        }

        public string return_direction()
        {
            return direction;
        }

        public string return_type()
        {
            return type;
        }

        public string return_music()
        {
            return music;
        }

        public string return_date_of_production()
        {
            return date_of_production;
        }


        public string return_time()
        {
            return time;
        }

    }
}
