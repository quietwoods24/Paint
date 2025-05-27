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
    public class FilledPolygon : Shape2D
    {
        public override Color FillColor { get; set; }

        public FilledPolygon(Color fillColor, params Point2D[] points) : base(points)
        {
            FillColor = fillColor;
        }
        public override string ToString()
        {
            string[] fields =
            {
                base.ToString(),
                $"Fill color: {FillColor}"
            };
            return String.Join(delimeter, fields);
        }
    }
}
