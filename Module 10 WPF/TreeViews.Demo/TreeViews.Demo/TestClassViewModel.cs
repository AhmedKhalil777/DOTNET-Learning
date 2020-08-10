using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace TreeViews.Demo
{
    [AddINotifyPropertyChangedInterface]
    public class TestClassViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public string Test { get; set; }

        public TestClassViewModel()
        {
            Task.Run(async () => {
                int y = 0;
                while (true)
                {
                    await Task.Delay(200);
                    Test = (++y).ToString();
                }
            
            });
        }
    }
}
