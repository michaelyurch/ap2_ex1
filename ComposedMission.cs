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

        string nameVal;
        string typeVal;

        public ComposedMission(string _name)
        {
            this.nameVal = _name;
            this.typeVal = "Composed";
            this.listOfMissions = new List<Func<double, double>>();
        }

        public string Name
        {
            get
            {
                return this.nameVal;
            }
        }

        public string Type
        {
            get
            {
                return this.typeVal;
            }
        }

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            OnCalculate?.Invoke(this, value);
            int i = 0;
            double lastResult = 0;
            foreach (Func<double, double> function in this.listOfMissions)
            {
                if (i == 0)
                {
                    lastResult = function(value);
                } 

                else
                {
                    lastResult = function(lastResult);
                }

                i++;
            }
            return lastResult;
        }

        public ComposedMission Add(Func<double, double> function)
        {
            this.listOfMissions.Add(function);
            return this;
        }
    }
}
