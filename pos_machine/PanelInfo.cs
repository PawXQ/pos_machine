using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_machine
{
    internal class PanelInfo
    {
        public FlowLayoutPanel flowLayoutPanel;
        public int total_price;
        public PanelInfo(FlowLayoutPanel flowLayoutPanel, int total_price)
        {
            this.flowLayoutPanel = flowLayoutPanel;
            this.total_price = total_price;
        }
    }
}
