/* Author: Joe Webster
 * Date: 10/12/2017
 * Class: CIS 300 B
 * Instructor: Dr. Weese
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.MapViewer
{
    public partial class Map : UserControl
    {
        /// <summary>
        /// Private field _maxZoom is const and therefore immutable; used for setting the maximum zoom
        /// </summary>
        private const int _maxZoom = 6;

        /// <summary>
        /// Private field _scale is used for altering the scale at which the map is displayed
        /// </summary>
        private int _scale;

        /// <summary>
        /// Private field _zoom is used to store the zoom level
        /// </summary>
        private int _zoom;

        /// <summary>
        /// Private field _uxMap is used for making a Quadtree for storing and organizing the map information
        /// </summary>
        private QuadTree _uxMap;

        /// <summary>
        /// Public method Map is an overloaded constructor for the Map class
        /// </summary>
        /// <param name="street">This param is used to initialize a Quadtree stored in _uxMap field</param>
        /// <param name="bounds">This param is used to initialize the _uxMap field</param>
        /// <param name="scaleFactor">This param is used to initilize the _scale field</param>
        public Map(List<StreetSegment> street, RectangleF bounds, int scaleFactor)
        {
            //checking if the street segment is within the bounds given
            for (int i = 0; i < street.Count; i++)
            {
                if (!IsWithinBounds(street[i].Start, bounds) || !IsWithinBounds(street[i].End, bounds))
                {
                    throw new ArgumentException("Street " + i + " is not within the given bounds");
                }
            }
            InitializeComponent();
            _uxMap = new QuadTree(street, bounds, _maxZoom);
            _scale = scaleFactor;
            size = new Size((int)bounds.Width * scaleFactor, (int)bounds.Height * scaleFactor);
        }

        /// <summary>
        /// Size returns the size of the map
        /// </summary>
        public Size size
        {
            get
            {
                return Size;
            }
            set
            {
                Size = value;
            }
        }

        /// <summary>
        /// CanZoomIn checks if the user can zoom in and returns a bool
        /// </summary>
        public bool CanZoomIn
        {
            get
            {
                return _zoom < _maxZoom;
            }
        }

        /// <summary>
        /// CanZoomOut checks if the user can zoom out and returns a bool
        /// </summary>
        public bool CanZoomOut
        {
            get
            {
                return _zoom > 0;
            }
        }

        /// <summary>
        /// ZoomOut zooms out on the map
        /// </summary>
        public void ZoomOut()
        {
            if (CanZoomOut)
            {
                _zoom--;
                size = new Size(size.Width / 2, size.Height / 2);
                _scale = _scale / 2;
                Invalidate();
            }
        }

        /// <summary>
        /// ZoomIn zooms in on the map
        /// </summary>
        public void ZoomIn()
        {
            if (CanZoomIn)
            {
                _zoom++;
                size = new Size(size.Width * 2, size.Height * 2);
                _scale = _scale * 2;
                Invalidate();
            }
        }

        /// <summary>
        /// IsWithinBounds returns if the point given "point" is within the bounds of the map
        /// </summary>
        /// <param name="point">PointF gives us the floats "x" and "y" to compare to rectangle.Left, rectange.Right. rectangle.Top, retangle.Bottom</param>
        /// <param name="rectangle">the bounds passed in for comparison with the PointF param</param>
        /// <returns></returns>
        private static bool IsWithinBounds(PointF point, RectangleF rectangle)
        {
            return ((point.X >= rectangle.Left && point.X <= rectangle.Right) && (point.Y >= rectangle.Top && point.Y <= rectangle.Bottom));
        }

        /// <summary>
        /// Overriden OnPaint draws the map using the "Draw" method form Quadtree
        /// </summary>
        /// <param name="e">This is the event from the OnPaint method</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle bounds = e.ClipRectangle;
            Graphics graphic = e.Graphics;
            graphic.Clip = new Region(bounds);
            //maybe _maxZoom
            _uxMap.Draw(graphic, _scale, _zoom);
        }
    }
}
