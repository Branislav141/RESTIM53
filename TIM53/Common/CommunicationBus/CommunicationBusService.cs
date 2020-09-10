using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.CommunicationBus
{
    public class CommunicationBusService
    {
        public XNode Node{ get; set; }
        XMLToSQL xMLToSQL = new XMLToSQL();

        public CommunicationBusService()
        {
        }

        public CommunicationBusService(XNode node)
        {
            Node = node;
            Run();
        }
        public void Run(XNode node = null)
        {
            if(node != null)
            {
                Node = node;
            }
            xMLToSQL.ConvertAndRun(Node);
            
        }
    }
}
