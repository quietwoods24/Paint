using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Added manually for Drawing
using System.Drawing;
using System.Windows.Forms;
// https://www.newtonsoft.com/json
using Newtonsoft.Json;

namespace Paint
{
    public class Polygon : Shape2D
    {
        public Polygon(params Point2D[] points) : base(points)
        {
            // Do nothing
        }

    }    
}
