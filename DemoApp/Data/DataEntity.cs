using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Data
{
    public class DataEntity
    {
       public demoEntities demo = new demoEntities();
       public static DataEntity Instance = new DataEntity();
    }
}
