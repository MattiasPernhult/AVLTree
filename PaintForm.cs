using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinärtSökTräd_AVL
{
    public partial class PaintForm : Form
    {
        BinaryTree newTree;

        public PaintForm()
        {
            InitializeComponent();
            newTree = new BinaryTree();
            txtData.Focus();
        }

        private void DrawTree()
        {
            int temp;
            pBoxTree.Image = newTree.Draw(out temp, null);
            pBoxTree.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            int data = int.Parse(txtData.Text);
            if (!(data > 999))
            {
                try
                {
                    newTree.Add(data);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                DrawTree();
                txtData.Text = "";
            }
            else
                MessageBox.Show("Får inte innehålla värden som är större än 999");
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            int data = int.Parse(txtData.Text);
            newTree.Delete(data);
            DrawTree();
        }

        private void txtData_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd_Click_1(btnAdd, new EventArgs());
        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            bool isIn = newTree.Find(int.Parse(txtData.Text));
            if (isIn)
                MessageBox.Show("Ditt värde finns i trädet!");
            else
                MessageBox.Show("Ditt värde finns inte i trädet!");
        }

        private void btnIn_Click_1(object sender, EventArgs e)
        {
            StringBuilder builder = newTree.DisplayOrder(1);
            MessageBox.Show(builder.ToString());
        }

        private void btnPre_Click_1(object sender, EventArgs e)
        {
            StringBuilder builder = newTree.DisplayOrder(2);
            MessageBox.Show(builder.ToString());
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            StringBuilder builder = newTree.DisplayOrder(3);
            MessageBox.Show(builder.ToString());
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                pBoxTree.Image.Save("C:\\Users\\Mattias\\Pictures\\AVL\\AVL " + newTree.Count + ".jpg");
                MessageBox.Show("Bilden är sparad till dina bilder i mappen AVL!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
