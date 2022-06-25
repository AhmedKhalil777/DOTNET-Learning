using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaphore.Sample
{
    public class ThreadsManager
    {
        private  System.Threading.Semaphore _semaphore;

        public ThreadsManager(int semaphoreInitialCount, int semaphoreMaxCount)
        {
            _semaphore = new System.Threading.Semaphore(semaphoreInitialCount, semaphoreMaxCount);
        }

        public void Start(Action<System.Threading.Semaphore> action)
        {
            action.Invoke(_semaphore);
        }

    }
}
