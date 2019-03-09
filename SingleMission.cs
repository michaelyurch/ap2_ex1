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

        string NameVal;         // holds name of function
        string TypeVal;         // holds type of function

        public SingleMission(Func<double, double> _function, string _name)
        {
            this.NameVal = _name;
            this.TypeVal = "Single";
            Function = _function;
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
            OnCalculate?.Invoke(this, this.Function(value));    // calculation has been handeled
            return this.Function(value);
        }
    }
}
