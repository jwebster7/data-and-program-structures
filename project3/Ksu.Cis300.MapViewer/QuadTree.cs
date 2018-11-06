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
    class QuadTree
    {
        /// <summary>
        /// This private field stores the southwest quadrent of the map
        /// </summary>
        private QuadTree _southwestChild;

        /// <summary>
        /// This private field stores the southeast quadrent of the map
        /// </summary>
        private QuadTree _southeastChild;

        /// <summary>
        /// This private field stores the northwest quadrent of the map
        /// </summary>
        private QuadTree _northwestChild;

        /// <summary>
        /// This private field stores the northeast quadrent of the map
        /// </summary>
        private QuadTree _northeastChild;

        /// <summary>
        /// This private field stores the bounds of the map 
        /// </summary>
        private RectangleF _bounds;

        /// <summary>
        /// This private field makes a List of StreetSegments
        /// </summary>
        private List<StreetSegment> _streets = new List<StreetSegment>();

        /// <summary>
        /// Public constructor Quadtree initializes the fields by calling other methods in the Quadtree class
        /// </summary>
        /// <param name="street">This param is used to initialize __streets</param>
        /// <param name="treeArea">This param is used to initialize _bounds</param>
        /// <param name="height">This param used to see if the List street</param>
        public QuadTree(List<StreetSegment> street, RectangleF treeArea, int height)
        {
            //initializing the RectangleF...
            _bounds = treeArea;

            if (height == 0)
            {
                _streets = street;
            }
            else
            {
                _streets = new List<StreetSegment>();
                List<StreetSegment> invis = new List<StreetSegment>();

                //used for SplitEastWest method
                List<StreetSegment> east = new List<StreetSegment>();
                List<StreetSegment> west = new List<StreetSegment>();

                //Four Quadrents
                List<StreetSegment> northEast = new List<StreetSegment>();
                List<StreetSegment> northWest = new List<StreetSegment>();
                List<StreetSegment> southEast = new List<StreetSegment>();
                List<StreetSegment> southWest = new List<StreetSegment>();

                float midX = (_bounds.Width / 2) + _bounds.Left;
                float midY = (_bounds.Height / 2) + _bounds.Top;

                SplitHeights(street, height, _streets, invis);
                SplitEastWest(street, midX, west, east);
                SplitNorthSouth(east, midY, southEast, northEast);
                SplitNorthSouth(west, midY, southWest, northWest);

                //creating the spaces of the quadrents
                RectangleF northWestQuad = new RectangleF(_bounds.Left, _bounds.Top, _bounds.Width / 2, _bounds.Height / 2);
                RectangleF northEastQuad = new RectangleF(midX, _bounds.Top, _bounds.Width / 2, _bounds.Height / 2);
                RectangleF southWestQuad = new RectangleF(_bounds.Left, midY, _bounds.Width / 2, _bounds.Height / 2);
                RectangleF southEastQuad = new RectangleF(midX, midY, _bounds.Width / 2, _bounds.Height / 2);

                //creating QuadTrees for the Quadrents
                _northwestChild = new QuadTree(northWest, northWestQuad, height - 1);
                _northeastChild = new QuadTree(northEast, northEastQuad, height - 1);
                _southwestChild = new QuadTree(southWest, southWestQuad, height - 1);
                _southeastChild = new QuadTree(southEast, southEastQuad, height - 1);
            }
        }

        /// <summary>
        /// Public method Draw is used to draw lines on the map
        /// </summary>
        /// <param name="graphic">This param is used to construct RectangleF's in order to draw the map lines</param>
        /// <param name="scaleFactor">This param is used for recursively calling the Draw method</param>
        /// <param name="depth">This param is used for recursively calling the Draw method</param>
        public void Draw(Graphics graphic, int scaleFactor, int depth)
        {

            RectangleF tempRectangle = new RectangleF(graphic.ClipBounds.X / scaleFactor,
                                                      graphic.ClipBounds.Y / scaleFactor,
                                                      graphic.ClipBounds.Width / scaleFactor,
                                                      graphic.ClipBounds.Height / scaleFactor);

            if (_bounds.IntersectsWith(tempRectangle))
            {
                foreach (StreetSegment street in _streets)
                {
                    street.Draw(graphic, scaleFactor);
                }
                if (depth > 0)
                {
                    _northwestChild.Draw(graphic, scaleFactor, depth - 1);
                    _northeastChild.Draw(graphic, scaleFactor, depth - 1);
                    _southeastChild.Draw(graphic, scaleFactor, depth - 1);
                    _southwestChild.Draw(graphic, scaleFactor, depth - 1);
                }
            }

        }

        /// <summary>
        /// Private method SpliHeights is used to seperate the List into visible and invisible street segments
        /// </summary>
        /// <param name="splitSegments">This param is passed in to split</param>
        /// <param name="treeHeight">This param is used for seperating the segments</param>
        /// <param name="visibleTreesList">This param is used for storing the visiblie segments of each segment are greater than the treeHeight</param>
        /// <param name="invisibleTreesList">This param is used for storing the invisible segments of each segment is less than treeHeight</param>
        private static void SplitHeights(List<StreetSegment> splitSegments, int treeHeight, List<StreetSegment> visibleTreesList, List<StreetSegment> invisibleTreesList)
        {
            //Iterate through segments to split
            foreach (StreetSegment segment in splitSegments)
            {
                //if the visiblieTreesList > treeHeight
                if (segment.VisibleLevels > treeHeight)
                {
                    //Add the tree at that location to the visibleTreeList
                    visibleTreesList.Add(segment);
                }
                //else
                else
                {
                    //Add the tree at that location to the invisibleTreeList
                    invisibleTreesList.Add(segment);
                }
            }
        }

        /// <summary>
        /// Private method SplitEastWest splits street segments into an east portion and a west portion
        /// </summary>
        /// <param name="splitSegments">The segments to split</param>
        /// <param name="givenX">A given int to determine where to place the split segments</param>
        /// <param name="westSegmentsList">the western segments</param>
        /// <param name="eastSegmentsList">the eastern segments</param>
        private static void SplitEastWest(List<StreetSegment> splitSegments, float givenX, List<StreetSegment> westSegmentsList, List<StreetSegment> eastSegmentsList)
        {
            foreach (StreetSegment segment in splitSegments)
            {
                //beginning x coordinates
                float x1 = segment.End.X;

                //ending x coordinates
                float x2 = segment.Start.X;

                //Case 1: Both endpoints x-coordinates are no greater than the givenX
                if (x1 <= givenX && x2 <= givenX)
                {
                    westSegmentsList.Add(segment);
                }

                //Case 2: Both endpoints x-coordinates are no less than the givenX
                else if (x1 >= givenX && x2 >= givenX)
                {
                    eastSegmentsList.Add(segment);
                }

                //Case 3: one endpoint is west of vertical line, other is east.
                //In this case we split the segment into two segments with
                //One segment lying to the west of the vertical line and the other to the east
                else
                {
                    float newY = ((segment.End.Y - segment.Start.Y) / (segment.End.X - segment.Start.X) * (givenX - segment.Start.X)) + segment.Start.Y;

                    StreetSegment s1 = segment;
                    StreetSegment s2 = segment;
                    s1.End = new PointF(givenX, newY);
                    s2.Start = new PointF(givenX, newY);
                    if (s1.Start.X <= givenX)
                    {
                        eastSegmentsList.Add(s2);
                        westSegmentsList.Add(s1);
                    }

                    if (s2.Start.X >= givenX)
                    {
                        eastSegmentsList.Add(s1);
                        westSegmentsList.Add(s2);
                    }
                }
            }
        }

        /// <summary>
        /// Private method SplitNorthSouth seperates segments into lists of north or south based on a given Y and a segment
        /// </summary>
        /// <param name="splitSegments">Segments to split</param>
        /// <param name="givenY">The given Y coordinate</param>
        /// <param name="northSegmentsList">A list of the segments going to the North</param>
        /// <param name="southSegmentsLIst">A list of the segments going to the South</param>
        private static void SplitNorthSouth(List<StreetSegment> splitSegments, float givenY, List<StreetSegment> southSegmentsList, List<StreetSegment> northSegmentsList)
        {
            foreach (StreetSegment segment in splitSegments)
            {
                //beginning y coordinates
                float y1 = segment.Start.Y;

                //ending y coordinates
                float y2 = segment.End.Y;

                //Case 1: Both endpoints y-coordinates are no greater than the givenX
                if (y1 <= givenY && y2 <= givenY)
                {
                    northSegmentsList.Add(segment);
                }

                //Case 2: Both endpoints x-coordinates are no less than the givenX
                else if (y1 >= givenY && y2 >= givenY)
                {
                    southSegmentsList.Add(segment);
                }

                //Case 3: one endpoint is west of vertical line, other is east.
                //In this case we split the segment into two segments with
                //One segment lying to the west of the vertical line and the other to the east
                else
                {
                    float newX = ((segment.End.X - segment.Start.X) / (segment.End.Y - segment.Start.Y) * (givenY - segment.Start.Y)) + segment.Start.X;

                    StreetSegment s1 = segment;
                    StreetSegment s2 = segment;
                    s1.End = new PointF(newX, givenY);
                    s2.Start = new PointF(newX, givenY);
                    if (s1.Start.Y <= givenY)
                    {
                        southSegmentsList.Add(s2);
                        northSegmentsList.Add(s1);
                    }

                    if (s2.Start.X >= givenY)
                    {
                        southSegmentsList.Add(s1);
                        northSegmentsList.Add(s2);
                    }
                }
            }
        }

    }
}
