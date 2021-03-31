using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
   abstract class InfoBase<T,C>
    {

        private List<C> points;

        public List<C> Points
        {
            get
            {
                points = points.Skip(1).Append(TakeInfo()).ToList();
                return points;
            }
        }

        protected abstract C TakeInfo();

        public InfoBase()
        {
            points = new List<C>();
            for (int i = 0; i < 60; i++)
            {
                points.Add(InitilizatorC());
            }
        }

        protected abstract C InitilizatorC();

        protected ManagementObjectSearcher TakeManagementObject(string whatTaking, string whereTaking)
        {
            return new ManagementObjectSearcher(String.Format("Select {0} from {1}", whatTaking, whereTaking));
        }

        public abstract List<T> TakeInfoAboutDivice();
        

    }
}
