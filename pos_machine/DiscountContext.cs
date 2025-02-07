using pos_machine.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_machine
{
    internal class DiscountContext
    {
        ADiscountStrategy ADiscount;

        public DiscountContext(ADiscountStrategy ADiscount)
        {
            this.ADiscount = ADiscount;
        }
        public void GetResult()
        {
            ADiscount.Discount();
        }
    }
}
