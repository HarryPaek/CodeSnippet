using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TreeViewDragDrop
{
    public partial class TreeViewForm : Form
    {
        public TreeViewForm()
        {
            InitializeComponent();
        }

        private void TreeViewForm_Load(object sender, EventArgs e)
        {
            TreeNode rootNode = null;

            for (int idx = 0; idx < 101; idx++)
            {
                if (idx % 10 == 0) {
                    if (rootNode != null)
                        this.treeView.Nodes.Add(rootNode);

                    rootNode = new TreeNode(string.Format("Root [{0:D3}]", idx));
                }
                else {
                    TreeNode child = new TreeNode(idx.ToString());
                    rootNode.Nodes.Add(child);
                }
            }
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = this.treeView.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = this.treeView.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode)) {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move) {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                }

                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();
            }
        }

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
                DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = this.treeView.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            TreeNode targetNode = this.treeView.GetNodeAt(targetPoint);

            Debug.WriteLine(string.Format("draggedNode = [{0}], targetNode = [{1}]", draggedNode, targetNode));

            if (targetNode.Text.Contains("6"))
            {
                e.Effect = DragDropEffects.None;
                this.treeView.SelectedNode = null;
            }
            else
            {
                e.Effect = e.AllowedEffect;
                // Select the node at the mouse position.
                this.treeView.SelectedNode = this.treeView.GetNodeAt(targetPoint);
            }
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }
    }
}
