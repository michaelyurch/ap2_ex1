using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        List<Func<double, double>> listOfMissions;

        string NameVal;         // holds name of function
        string TypeVal;         // holds type of function

        public ComposedMission(string _name)
        {
            this.NameVal = _name;
            this.TypeVal = "Composed";
            this.listOfMissions = new List<Func<double, double>>();
        }

        public string Name
        {
            get
            {
                return this.NameVal;
            }
        }

        public string Type
        {
            get
            {
                return this.TypeVal;
            }
        }

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            int i = 0;                  // counts iterations of loop
            double lastResult = 0;      // outout of last function

            // pass each function step by step
            foreach (Func<double, double> function in this.listOfMissions)
            {

                // if this is the first iteration
                if (i == 0)
                {
                    lastResult = function(value);       // use given value as function's input
                } 

                else
                {
                    lastResult = function(lastResult);      // use output of last func. as input
                }

                i++;
            }
            OnCalculate?.Invoke(this, lastResult);      //calculation has been handeled
            return lastResult;
        }

        public ComposedMission Add(Func<double, double> function)
        {
            this.listOfMissions.Add(function);
            return this;
        }
    }
}
