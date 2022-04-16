using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VDS.RDF;
using VDS.RDF.Ontology;

namespace OwlGenerator.View
{
    public partial class MainWindow : Form
    {
        private TreeNode SelectedNode;
        private readonly OntologyService _ontologyService = new();
        private readonly OntologyGraph _graph = new();

        public MainWindow()
        {
            InitializeComponent();
            treeView1.Nodes.Clear();
            treeView1.NodeMouseClick += TreeView1_mouseDown;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Save.Focus();
        }

        private void TreeView1_mouseDown(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SelectedNode = e.Node;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void addSubClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = "";
            
            ShowInputDialogBox(ref input, "Please enter subclass name", "Create Subclass", 300, 100);

            if (!string.IsNullOrEmpty(input))
            {
                _ontologyService.CreateSubClass(_graph, GetParentNodePath(SelectedNode), input);
                var node = SelectedNode.Nodes.Add(input, input);
                node.ForeColor = Color.DarkGreen;
            }
        }

        private string GetParentNodePath(TreeNode selectedNode)
        {
            var path = selectedNode.FullPath;
            path = path.Replace("\\", "/");
            return path;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAllChilds(SelectedNode);

        }

        private void DeleteAllChilds(TreeNode node)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    DeleteAllChilds(child);
                }
            }
            _ontologyService.DeleteClass(_graph, node.FullPath.Replace("\\", "/"));

            node.Remove();
        }

        private void CreateThing_Click(object sender, EventArgs e)
        {
            var node = treeView1.Nodes.Add("Thing", "Thing");
            _ontologyService.CreateClass(_graph, "Thing");
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = "";
            //Display the custom input dialog box with the following prompt, window title, and dimensions
            ShowInputDialogBox(ref input, "Please enter new name", "Edit", 300, 100);

            if (!string.IsNullOrEmpty(input))
            {
                _ontologyService.UpdateUriNode(_graph, GetParentNodePath(SelectedNode.Parent), input,  SelectedNode.Text);
                SelectedNode.Text = input;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "RDF Files|*.rdf";
            saveFileDialog.Title = "Save an RDF File";
            saveFileDialog.ShowDialog();
            

            _graph.SaveToFile(saveFileDialog.FileName + ".rdf");
        }

        private void Open_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "RDF Files|*.rdf";
            openFileDialog.Title = "Select a RDF File";
            openFileDialog.ShowDialog();
            _graph.LoadFromFile(openFileDialog.FileName);

            treeView1.Nodes.Clear();
            var nodes = _ontologyService.GetNodes(_graph);

            treeView1.Nodes.Add(nodes[0].Replace("/",""), nodes[0].Replace("/", ""));

            for (int i = 1; i < nodes.Count; ++i)
            {
                var name = nodes[i].Substring(nodes[i].LastIndexOf('/') + 1);
                var parent = nodes[i].Substring(0, nodes[i].LastIndexOf('/'));
                var parentName = parent.Substring(parent.LastIndexOf('/') + 1);

                var node = FindNode(parentName, treeView1.Nodes)?.Nodes.Add(name, name);

            }

        }

        private TreeNode FindNode(string parentName, TreeNodeCollection collection)
        {
            foreach (TreeNode node in collection)
            {
                if (node.Text == parentName)
                {
                    return node;
                }

                var found = FindNode(parentName, node.Nodes);
                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }

        private void AddIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = "";

            ShowInputDialogBox(ref input, "Please enter individual name", "Create Individual", 300, 100);

            if (!string.IsNullOrEmpty(input))
            {
                _ontologyService.CreateIndividual(_graph, GetParentNodePath(SelectedNode), input);
                var node = SelectedNode.Nodes.Add(input, input,1);
                node.ForeColor = Color.Yellow;
            }
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;

            var result = _ontologyService.ExecuteQuery(_graph, text);
            
            MessageBox.Show(result.ToString());
        }

        private static DialogResult ShowInputDialogBox(ref string input, string prompt, string title = "Title",
            int width = 300, int height = 200)
        {
            //This function creates the custom input dialog box by individually creating the different window elements and adding them to the dialog box

            //Specify the size of the window using the parameters passed
            Size size = new Size(width, height);
            //Create a new form using a System.Windows Form
            Form inputBox = new Form();

            inputBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            //Set the window title using the parameter passed
            inputBox.Text = title;

            //Create a new label to hold the prompt
            Label label = new Label();
            label.Text = prompt;
            label.Location = new Point(5, 5);
            label.Width = size.Width - 10;
            inputBox.Controls.Add(label);

            //Create a textbox to accept the user's input
            TextBox textBox = new TextBox();
            textBox.Size = new Size(size.Width - 10, 23);
            textBox.Location = new Point(5, label.Location.Y + 20);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            //Create an OK Button 
            Button okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 30);
            okButton.Text = "&OK";
            okButton.Location = new Point(size.Width - 80 - 80, size.Height - 45);
            inputBox.Controls.Add(okButton);

            //Create a Cancel Button
            Button cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 30);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new Point(size.Width - 80, size.Height - 45);
            inputBox.Controls.Add(cancelButton);

            //Set the input box's buttons to the created OK and Cancel Buttons respectively so the window appropriately behaves with the button clicks
            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            //Show the window dialog box 
            //inputbox in middle of screen
            inputBox.StartPosition = FormStartPosition.CenterScreen;
            DialogResult result = inputBox.ShowDialog();

            if (result == DialogResult.OK)
                input = textBox.Text;


            //After input has been submitted, return the input value
            return result;
        }
    }
}