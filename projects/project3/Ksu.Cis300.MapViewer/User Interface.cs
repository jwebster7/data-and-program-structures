/* Author: Joe Webster
 * Date: 10/12/2017
 * Class: CIS 300 B
 * Instructor: Dr. Weese
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ksu.Cis300.MapViewer
{
    public partial class uxUserInterface : Form
    {
        /// <summary>
        /// Private field _mapField is the instantiation we will use for displaying the world
        /// </summary>
        private Map _mapField;

        /// <summary>
        /// Private field _initialScale is the constant used to construct the initial map
        /// </summary>
        private const int _initialScale = 10;

        /// <summary>
        /// Public Constructor for the uxUserInterface class
        /// </summary>
        public uxUserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Private method ReadFile reads the contents of a file using a StreamReader and mapBounds
        /// </summary>
        /// <param name="fileName">This string is the filename passed in</param>
        /// <param name="mapBounds">Passed as a reference, this RectangleF will contain the bounds of the map</param>
        /// <returns></returns>
        private static List<StreetSegment> ReadFile(string fileName, out RectangleF mapBounds)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string[] lines;
                List<StreetSegment> streets = new List<StreetSegment>();
                string heightAndWidth = sr.ReadLine();
                string[] fields = heightAndWidth.Split(',');
                mapBounds = new RectangleF(0, 0, Convert.ToSingle(fields[0]), Convert.ToSingle(fields[1]));

                while (!sr.EndOfStream)
                {
                    fields = sr.ReadLine().Split(',');
                    float x1 = Convert.ToSingle(fields[0]);
                    float y1 = Convert.ToSingle(fields[1]);
                    float x2 = Convert.ToSingle(fields[2]);
                    float y2 = Convert.ToSingle(fields[3]);

                    PointF point1 = new PointF(x1, y1);
                    PointF point2 = new PointF(x2, y2);

                    Color color = Color.FromArgb(Convert.ToInt32(fields[4]));
                    float width = Convert.ToSingle(fields[5]);
                    int zoom = Convert.ToInt32(fields[6]);
                    StreetSegment street = new StreetSegment(point1, point2, color, width, zoom);
                    streets.Add(street);
                }

                return streets;
            }
        }

        /// <summary>
        /// Private method uxOpenMap_Click is an event handler for when the "Open Map" button is selected
        /// </summary>
        /// <param name="sender">This is a reference to the object, in this case the "Open Map" button</param>
        /// <param name="e">This object is the data from the event</param>
        private void uxOpenMap_Click(object sender, EventArgs e)
        {
            if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RectangleF rectangle;
                    List<StreetSegment> streetList = ReadFile(uxOpenFileDialog.FileName, out rectangle);
                    _mapField = new Map(streetList, rectangle, _initialScale);
                    uxPanel.Controls.Clear();
                    uxPanel.Controls.Add(_mapField);
                    uxZoomIn.Enabled = true;
                    uxZoomOut.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Private method uxZoomIn_Click is an event handler for the "Zoom In" button
        /// </summary>
        /// <param name="sender">This is a reference to the object, in this case the "Zoom In" button</param>
        /// <param name="e">This object is the data from the event</param>
        private void uxZoomIn_Click(object sender, EventArgs e)
        {
            int x = (-1) * uxPanel.AutoScrollPosition.X;
            int y = (-1) * uxPanel.AutoScrollPosition.Y;
            Point coordinates = new Point(x, y);
            Point scrollBar = uxPanel.AutoScrollPosition;
            scrollBar = new Point(x, y);
            _mapField.ZoomIn();
            uxZoomIn.Enabled = _mapField.CanZoomIn;
            uxZoomOut.Enabled = true;
            int width = uxPanel.ClientSize.Width;
            int height = uxPanel.ClientSize.Height;
            int x2 = (2 * -x) + (width / 2);
            int y2 = (2 * -y) + (height / 2);
            Point position = new Point(x2, y2);
            uxPanel.AutoScrollPosition = position;
        }

        /// <summary>
        /// Private method uxZoomOut_Click is an event handler for the "Zoom Out" button
        /// </summary>
        /// <param name="sender">This is a reference to the object, in this case the "Zoom Out" button</param>
        /// <param name="e">This object is the data from the event</param>
        private void uxZoomOut_Click(object sender, EventArgs e)
        {
            int x = (-1) * uxPanel.AutoScrollPosition.X;
            int y = (-1) * uxPanel.AutoScrollPosition.Y;
            Point coordinates = new Point(x, y);
            Point scrollBar = uxPanel.AutoScrollPosition;
            scrollBar = new Point(x, y);
            _mapField.ZoomOut();
            uxZoomOut.Enabled = _mapField.CanZoomOut;
            uxZoomIn.Enabled = true;
            int width = uxPanel.ClientSize.Width;
            int height = uxPanel.ClientSize.Height;
            int x2 = (-x / 2) - (width / 4);
            int y2 = (-y / 2) - (height / 4);
            Point position = new Point(x2, y2);
            uxPanel.AutoScrollPosition = position;
        }
    }
}
