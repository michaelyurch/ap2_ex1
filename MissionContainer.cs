using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
  
    public class FunctionsContainer
    {
        Dictionary<string, Func<double, double>> missions;

        public FunctionsContainer()
        {
            this.missions = new Dictionary<string, Func<double, double>>();
        }

        public Func<double, double> this[string key]
        {
            get
            {
                List<string> keys = new List<string>(this.missions.Keys);
                if (!keys.Contains(key))
                {
                    missions[key] = val => val;
                }

                return this.missions[key];
            }
            set
            {
                missions[key] = value;
            }
        }

        public List<string> getAllMissions()
        {
            return new List<string>(this.missions.Keys);
        }

    }
}
