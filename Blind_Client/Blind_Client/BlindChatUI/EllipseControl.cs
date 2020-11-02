using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace Blind_Client.BlindChatUI
{
    class EllipseControl: Component
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );
        private Control _ctrl;
        private int _CornerRadius = 30;
        
        public Control TargetControl
        {
            get { return _ctrl; }
            set 
            { 
                _ctrl = value;
                _ctrl.SizeChanged += (sender, eventArgs) => _ctrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _ctrl.Width, _ctrl.Height, _CornerRadius, _CornerRadius));

            }
        }
        public int CorenerRadius
        {
            get { return _CornerRadius; }
            set 
            { 
                _CornerRadius = value;
                if (_ctrl != null)
                {
                    _ctrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _ctrl.Width, _ctrl.Height, _CornerRadius, _CornerRadius));
                }
            }
        }
    }
}
