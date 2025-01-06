using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_machine
{
    internal class EventPanel
    {
        public static EventHandler<PanelInfo> panelHandler;

        public static void UpdatePanel(PanelInfo panelinfo)
        {
            panelHandler.Invoke(null, panelinfo);
        }
    }
}
