/* Author: Joe Webster
 * Date: 11/29/2017 - 12/1/2017
 * Instructor: Dr. Weese
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.TravelingSalesperson
{
    public class MSTNode : ITree
    {
        /// <summary>
        /// The weight of the graph edge that took us to this node
        /// </summary>
        private int _data = 0;

        /// <summary>
        /// The array index from the adjacency matrix of the parent node
        /// </summary>
        private int _parent = 0;

        /// <summary>
        /// The string representation of the node
        /// </summary>
        private string _label;

        /// <summary>
        /// The children of "this" node
        /// </summary>
        private List<MSTNode> _children = new List<MSTNode>();

        /// <summary>
        /// Gets/sets the _data field
        /// </summary>
        public int Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        /// <summary>
        /// Gets/sets the _parent field
        /// </summary>
        public int Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        /// <summary>
        /// Returns the representation of the node
        /// </summary>
        public object Root
        {
            get
            {
                string node = _label + "(" + _data.ToString() + ")";
                return node;
            }
        }

        /// <summary>
        /// Returns an array representation of _children field
        /// </summary>
        ITree[] ITree.Children
        {
            get
            {
                return _children.ToArray();
            }
        }

        /// <summary>
        /// Returns if the node is empty or not; always returns false 
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return false;

            }
        }

        /// <summary>
        /// Constructor for MTSNode; Initializes the _data, _parent, and _label fields
        /// </summary>
        /// <param name="data">int for the _data field</param>
        /// <param name="parent">int for the _parent field</param>
        /// <param name="label">string for the _label field</param>
        public MSTNode(int data, int parent, string label)
        {
            _data = data;
            _parent = parent;
            _label = label;
        }

        /// <summary>
        /// Method for adding a child to the _children field
        /// </summary>
        /// <param name="child">The node to add to _children</param>
        public void AddChild(MSTNode child)
        {
            _children.Add(child);
        }

        /// <summary>
        /// Recursive helper function to do a "pre-order, depth-first" walk on the children of the MST
        /// </summary>
        /// <param name="sb">Given sb to append processed children</param>
        private void Walk(StringBuilder sb)
        {
            sb.Append(" to ");
            sb.Append(_label);
            sb.Append(Environment.NewLine);
            sb.Append(_label);
            foreach (MSTNode child in _children)
            {
                child.Walk(sb);
            }
        }

        /// <summary>
        /// Method for initiating the "pre-order, depth-first" walk of the MST tree described
        /// in the prior helper function
        /// </summary>
        /// <returns>String from sb</returns>
        public string Walk()
        {
            //Accumulates the walk as each node is processed
            StringBuilder sb = new StringBuilder();
            sb.Append(_label);
            foreach (MSTNode child in _children)
            {
                child.Walk(sb);
            }
            sb.Append(" to ");
            sb.Append(_label);
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
