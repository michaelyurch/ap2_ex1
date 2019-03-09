using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {

        Func<double, double> Function { get; }

        string nameVal;
        string typeVal;

        public SingleMission(Func<double, double> _function, string _name)
        {
            this.nameVal = _name;
            this.typeVal = "Single";
            Function = _function;
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
            return this.Function(value);
        }
    }
}
