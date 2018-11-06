/* Author: Joe Webster
 * Date: 10/12/2017
 * Class: CIS 300 B
 * Instructor: Dr. Weese
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.MapViewer
{
    public struct StreetSegment
    {
        /// <summary>
        /// Private field _start holds floating point x and y for the start of the segment
        /// </summary>
        private PointF _start;
        
        /// <summary>
        /// Private field _end holds floating point x and y for the end of the segment
        /// </summary>
        private PointF _end;

        /// <summary>
        /// Private field _pen gives the color of the segment
        /// </summary>
        private Pen _pen;

        /// <summary>
        /// Private field _visibleLevels represents the # of zoom levels
        /// </summary>
        private int _visibleLevels;

        #region Properties
        /// <summary>
        /// property for _start field; gets and sets
        /// </summary>
        public PointF Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }

        /// <summary>
        /// property for _end field; gets and sets
        /// </summary>
        public PointF End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
            }
        }

        /// <summary>
        /// Property for _visiblelevels field; gets val of _visible levels
        /// </summary>
        public int VisibleLevels
        {
            get
            {
                return _visibleLevels;
            }
        }
        #endregion

        /// <summary>
        /// Method for drawing the map
        /// </summary>
        /// <param name="graphic">Graphic is an object which draws a map</param>
        /// <param name="scaleFactor">Scalefactor is the ratio in integer representation for converting x,y to pixels</param>
        public void Draw(Graphics graphic, int scaleFactor)
        {
            graphic.DrawLine(_pen, (_start.X * scaleFactor), (_start.Y * scaleFactor), (_end.X * scaleFactor), (_end.Y * scaleFactor));
        }

        /// <summary>
        /// Constructor for the StreetSegment struct
        /// </summary>
        /// <param name="begin">The beginning of the line</param>
        /// <param name="end">The end of the line</param>
        /// <param name="c">The color of the line</param>
        /// <param name="width">The width of the pen brush for the line</param>
        /// <param name="zoomLevel">The level at which the zoom is at</param>
        public StreetSegment(PointF begin, PointF end, Color c, float width, int zoomLevel)
        {
            _start = begin;
            _end = end;
            _pen = new Pen(c, width);
            _visibleLevels = zoomLevel;
        }
    }
}
