using System;
using System.Threading.Tasks;
using System.Threading;
using CurrencyTelegram_bot.Models.Parser;

namespace CurrencyTelegram_bot.WebBackGroud
{
    /// <summary>
    /// For doing parse task on different thread
    /// </summary>
    public class BackGroundWorker:IDisposable
    {
        private CancellationTokenSource m_cancel;
        private Task m_task;
        private TimeSpan m_interval;
        private bool m_running;

        public BackGroundWorker(TimeSpan interval)
        {
            m_interval = interval;
            m_running = true;
            m_cancel = new CancellationTokenSource();
            m_task = Task.Run(() => TaskLoop(), m_cancel.Token);
        }

        private void TaskLoop()
        {
            while (m_running)
            {
                StartParse.StartParser();

                Thread.Sleep(m_interval);
            }
        }

        public void Dispose()
        {
            m_running = false;

            if (m_cancel != null)
            {
                try
                {
                    m_cancel.Cancel();
                    m_cancel.Dispose();
                }
                catch { }
                finally
                {
                    m_cancel = null;
                }
            }
        }
    }
}