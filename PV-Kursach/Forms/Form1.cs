using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using PV_Kursach.Resources;
using System.IO;

namespace PV_Kursach
{

    public partial class Form1 : Form
    {
        List<Chess> figures = new List<Chess>();
        

        public Form1()
        {
            InitializeComponent();
            PopulateTreeView(0, null);

            treeView1.AllowDrop = true;
            treeView1.Dock = DockStyle.Fill;

            treeView1.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            treeView1.DragEnter += new DragEventHandler(treeView1_DragEnter);
            treeView1.DragOver += new DragEventHandler(treeView1_DragOver);
            treeView1.DragDrop += new DragEventHandler(treeView1_DragDrop);

           
        }
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
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
           
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {

            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
            treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint);
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = treeView1.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }
                else if (e.Effect == DragDropEffects.Copy)
                {
                    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                }


                targetNode.Expand();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateTreeView(0, null);

        }

        
        private void PopulateTreeView(int parentID, TreeNode parentNode)
        {
           
            figures.Add(new Chess() { ParentId = 0, ID = 1, Name = "King", Color = "White" });
            figures.Add(new Chess() { ParentId = 0, ID = 1, Name = "Queen", Color = "White" });
            figures.Add(new Chess() { ParentId = 1, ID = 2, Name = "Rook", Color = "White" });
            figures.Add(new Chess() { ParentId = 1, ID = 2, Name = "Knight", Color = "White" });
            figures.Add(new Chess() { ParentId = 1, ID = 2, Name = "Bishop", Color = "White" });
            figures.Add(new Chess() { ParentId = 2, ID = 3, Name = "Pawn", Color = "White" });
            var Filtered = figures.Where(item => item.ParentId == parentID);
            TreeNode childNode;
            foreach (var item in Filtered.ToList())
            {
                if (parentNode == null)
                    childNode = treeView1.Nodes.Add(item.Name);
                else
                    childNode = parentNode.Nodes.Add(item.Name);

                PopulateTreeView(item.ID, childNode);
            }
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlFile = new XmlSerializer(typeof(List<Chess>));
            FileStream fs = new FileStream(@"C:\Users\bruker\source\repos\PV Kursach\PV-Kursach\PV-Kursach\Resources\saved.xml", FileMode.Create, FileAccess.Write);
            xmlFile.Serialize(fs,figures);
            fs.Close();
        }
        public void SerializeTreeView(TreeView treeView, string fileName)
        {
            XmlTextWriter textWriter = new XmlTextWriter(fileName,
                                          System.Text.Encoding.ASCII);
            // writing the xml declaration tag
            textWriter.WriteStartDocument();
            //textWriter.WriteRaw("\r\n");
            // writing the main tag that encloses all node tags
            textWriter.WriteStartElement("TreeView");

            // save the nodes, recursive method
           // SaveNodes(treeView.Nodes, textWriter);

            textWriter.WriteEndElement();

            textWriter.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Glavni meni = new Glavni();
            this.Hide();
            meni.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Remove(treeView1.SelectedNode);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TreeNode newNode = new TreeNode("Text for new node");
            treeView1.SelectedNode.Nodes.Add(newNode);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Text = textBox1.Text;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
          
        }
    }
    public class Chess // Ima veze sa klasom,tipom serializacije
    {
        private int id;
        private int parentId;
        private string name;
        private string color;
        private string info;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public int ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        public string Color
        {
            get { return color; }
            set
            {
                if (value == "Black" || value == "White")
                {
                    color = value;
                }
                else
                {
                    Notifications.NotifyError();
                    MessageBox.Show("There are only black and white pieces in chess!");
                }
            }
        }

        public string Name { get; set; }

        public string Info { get; set; }
        public Chess() // Main constructor
        {

        }
        // Drag and drop
        public void ChangeColor()
        {
            if (Color == "White") { Color = "Black"; }
            else { Color = "White"; }
        }

        public void ShowInfo()
        {
            MessageBox.Show(Info);
        }



    }
}
