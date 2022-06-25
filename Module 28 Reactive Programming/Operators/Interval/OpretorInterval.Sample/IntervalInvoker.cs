using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpretorInterval.Sample
{
    public class IntervalInvoker<T>
    {
        private TimeSpan _waitFor;
        private Action<List<T>> _action;
        public List<T> List { get; set; }
        public IntervalInvoker(double seconds, Action<List<T>> action)
        {
            List = new List<T>();
            _waitFor = TimeSpan.FromSeconds(seconds);
            _action = action;
        }

        public void Invoke()
        {
            Observable.Interval(_waitFor)
                .Subscribe(i => {
                    if (List.Any())
                    {
                        _action.Invoke(List);
                    }
                    List = new List<T>();
                });
        }
    }
}
