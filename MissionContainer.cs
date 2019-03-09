using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
  
    public class FunctionsContainer
    {
        Dictionary<string, Func<double, double>> Missions;      // holds missions with name as key

        public FunctionsContainer()
        {
            this.Missions = new Dictionary<string, Func<double, double>>();
        }

        public Func<double, double> this[string key]
        {
            get
            {
                List<string> keys = new List<string>(this.Missions.Keys);       //get keys of dict.

                // if given key exists in dictionary
                if (!keys.Contains(key))
                {

                    // if it's no func. by given key then add identity func. by given key
                    Missions[key] = val => val;
                }

                // return function by given key
                return this.Missions[key];
            }
            set
            {
                // put function to dictionary by given key
                Missions[key] = value;
            }
        }

        public List<string> getAllMissions()
        {
            // return list of dictionary's keys
            return new List<string>(this.Missions.Keys);
        }
    }
}
