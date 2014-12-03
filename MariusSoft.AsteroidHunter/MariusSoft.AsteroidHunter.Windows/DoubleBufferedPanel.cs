using System.ComponentModel;
using System.Windows.Forms;

namespace MariusSoft.AsteroidHunter.Windows
{
    public class DoubleBufferedPanel : Panel
    {
        [DefaultValue(true)]
        public new bool DoubleBuffered
        {
            get
            {
                return base.DoubleBuffered;
            }
            set
            {
                base.DoubleBuffered = value;
            }
        }
    }
}
