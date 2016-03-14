using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    class Tile : PictureBox
    {
        public Rectangle rect;
        public int pictureId;

        public Tile(int width, int height, Image i)
        {
            rect = new Rectangle(0, 0, width, height);
            Image = i;
        }
    }
}
