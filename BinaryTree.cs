using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BinärtSökTräd_AVL
{
    class BinaryTree
    {
        private Node root;
        private StringBuilder builder = new StringBuilder();
        private int count;

        public int Count
        {
            get { return count; }
        }

        public void Add(int data)
        {
            Node newNode = new Node(data);
            try
            {
                root = (root == null) ? root = newNode : root = Insert(root, newNode);
                count++;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        public void Delete(int value)
        {
            root = Remove(root, value);
        }

        private Node Insert(Node current, Node newNode)
        {
            if (current == null)
            {
                current = newNode;
                return current;
            }
            else if (newNode.Data < current.Data)
            {
                current.Left = Insert(current.Left, newNode);
                current = Balance(current);
            }
            else if (newNode.Data > current.Data)
            {
                current.Right = Insert(current.Right, newNode);
                current = Balance(current);
            }
            else
            {
                throw new ArgumentException("Värdet finns redan i trädet.");
            }
            return current;
        }

        private Node Remove(Node current, int valueToRemove)
        {
            Node successor;
            if (current == null)
                return null;
            else
            {
                if (valueToRemove < current.Data)
                {
                    current.Left = Remove(current.Left, valueToRemove);
                    current = Balance(current);
                }
                else if (valueToRemove > current.Data)
                {
                    current.Right = Remove(current.Right, valueToRemove);
                    current = Balance(current);
                }
                else
                {
                    if (current.Right != null)
                    {
                        successor = current.Right;
                        while (successor.Left != null)
                        {
                            successor = successor.Left;
                        }
                        current.Data = successor.Data;
                        current.Right = Remove(current.Right, successor.Data);
                        current = Balance(current);
                    }
                    else
                    {
                        return current.Left;
                    }
                }
            }
            return current;
        }

        public bool Find(int valueToFind)
        {
            Node current = root;
            while (valueToFind != current.Data)
            {
                if (valueToFind < current.Data)
                    current = current.Left;
                else if (valueToFind > current.Data)
                    current = current.Right;
                if (current == null)
                    return false;
            }
            return true;
        }

        private Node Balance(Node current)
        {
            int balance = GetBalance(current);

            if (balance > 1)
            {
                if (GetBalance(current.Left) > 0)
                    current = RotateLeftLeft(current);
                else
                    current = RotateLeftRight(current);
            }
            else if (balance < -1)
            {
                if (GetBalance(current.Right) > 0)
                    current = RotateRightLeft(current);
                else
                    current = RotateRightRight(current);
            }
            return current;
        }

        private Node RotateLeftLeft(Node current)
        {
            Node node = current.Left;
            current.Left = node.Right;
            node.Right = current;
            return node;
        }

        private Node RotateLeftRight(Node current)
        {
            Node node = current.Left;
            current.Left = RotateRightRight(node);
            return RotateLeftLeft(current);
        }

        private Node RotateRightRight(Node current)
        {
            Node node = current.Right;
            current.Right = node.Left;
            node.Left = current;
            return node;
        }

        private Node RotateRightLeft(Node current)
        {
            Node node = current.Right;
            current.Right = RotateLeftLeft(node);
            return RotateRightRight(current);
        }

        /// <returns></returns>
        private int GetBalance(Node current)
        {
            int left = GetHeight(current.Left);
            int right = GetHeight(current.Right);
            int balance = left - right;
            return balance;
        }

  
        private int GetHeight(Node current)
        {
            int height = 0;

            if (current != null)
            {
                int left = GetHeight(current.Left);
                int right = GetHeight(current.Right);
                int theHighest = (left > right) ? left : right;
                height = theHighest + 1;
            }
            return height;
        }

        public StringBuilder DisplayOrder(int alt)
        {
            builder.Remove(0, builder.Length);
            switch (alt)
            {
                case 1:
                    {
                        InOrder(root);
                        return builder;
                    }
                case 2:
                    {
                        PreOrder(root);
                        return builder;
                    }
                case 3:
                    {
                        PostOrder(root);
                        return builder;
                    }
            }
            return null;
        }

        private void PreOrder(Node current)
        {
            if (current != null)
            {
                builder.Append("(" + current.Data + ")");
                PreOrder(current.Left);
                PreOrder(current.Right);
            }
        }

        private void PostOrder(Node current)
        {
            if (current != null)
            {
                PostOrder(current.Left);
                PostOrder(current.Right);
                builder.Append("(" + current.Data + ")");
            }
        }

        private void InOrder(Node current)
        {
            if (current != null)
            {
                InOrder(current.Left);
                builder.Append("(" + current.Data + ")");
                InOrder(current.Right);
            }
        }

        public string DrawTree()
        {
            return DrawNode(root);
        }

        private string DrawNode(Node current)
        {
            if (current == null)
                return "empty";
            if ((current.Left == null) && (current.Right == null))
                return "" + current.Data;
            if ((current.Left != null) && (current.Right == null))
                return "" + current.Data + "(" + DrawNode(current.Left) + ", _)";
            if ((current.Right != null) && (current.Left == null))
                return "" + current.Data + "(_," + DrawNode(current.Right) + ")";
            return current.Data + "(" + DrawNode(current.Left) + ", " + DrawNode(current.Right) + ")";
        }

        private static Bitmap nodebg = new Bitmap(30, 25);
        private static Size freeSpace = new Size(nodebg.Width / 8, (int)(nodebg.Height * 1.3f));
        private static readonly float Coef = nodebg.Width / 40f;
        private static Font font = new Font("Tahoma", 14f * Coef);
        private Image lastImage;
        private int lastImageLocation;

        public Image Draw(out int center, Node current)
        {
            center = lastImageLocation;
            int lcenter = 0;
            int rcenter = 0;

            if (root == null)
                return null;

            if (current == null)
                current = root;

            Image rnodeimg = null, lnodeimg = null;
            if (current.Left != null)
                lnodeimg = Draw(out lcenter, current.Left);
            if (current.Right != null)
                rnodeimg = Draw(out rcenter, current.Right);

            Size lsize = new Size();
            Size rsize = new Size();
            bool under = (lnodeimg != null) || (rnodeimg != null);

            if (lnodeimg != null)
                lsize = lnodeimg.Size;
            if (rnodeimg != null)
                rsize = rnodeimg.Size;

            int maxheight = lsize.Height;
            if (maxheight < rsize.Height)
                maxheight = rsize.Height;

            if (lsize.Width <= 0)
                lsize.Width = (nodebg.Width - freeSpace.Width) / 2;
            if (rsize.Width <= 0)
                rsize.Width = (nodebg.Width - freeSpace.Width) / 2;

            Size ressize = new Size
            {
                Width = lsize.Width + rsize.Width + freeSpace.Width,
                Height = nodebg.Size.Height + (under ? maxheight + freeSpace.Height : 0)
            };
            Bitmap result = new Bitmap(ressize.Width, ressize.Height);
            Graphics g = Graphics.FromImage(result);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), ressize));
            g.DrawImage(nodebg, lsize.Width - nodebg.Width / 2 + freeSpace.Width / 2, 0);
            String str = current.Data.ToString();
            g.DrawString(str, font, Brushes.Red, lsize.Width - nodebg.Width / 2 + freeSpace.Width / 2 + (2 + (str.Length == 1 ? 10 : str.Length == 2 ? 5 : 0)) * Coef, nodebg.Height / 2f - 12 * Coef);

            center = lsize.Width + freeSpace.Width / 2;
            Pen pen = new Pen(Brushes.CornflowerBlue, 1.2f * Coef)
            {
                EndCap = LineCap.ArrowAnchor,
                StartCap = LineCap.Round
            };

            float x1 = center;
            float y1 = nodebg.Height;
            float y2 = nodebg.Height + freeSpace.Height;
            float x2 = lcenter;

            float h = Math.Abs(y2 - y1);
            float w = Math.Abs(x2 - x1);

            if (lnodeimg != null)
            {
                g.DrawImage(lnodeimg, 0, nodebg.Size.Height + freeSpace.Height);
                List<PointF> points1 = new List<PointF>
                                  {
                                      new PointF(x1, y1),
                                      new PointF(x1 - w/6, y1 + h/3.5f),
                                      new PointF(x2 + w/6, y2 - h/3.5f),
                                      new PointF(x2, y2),
                                  };
                g.DrawCurve(pen, points1.ToArray(), 0.5f);
            }

            if (rnodeimg != null)
            {
                g.DrawImage(rnodeimg, lsize.Width + freeSpace.Width, nodebg.Size.Height + freeSpace.Height);
                x2 = rcenter + lsize.Width + freeSpace.Width;
                w = Math.Abs(x2 - x1);
                List<PointF> points = new List<PointF>
                {
                    new PointF(x1, y1),
                    new PointF(x1 + w/6, y1 + h/3.5f),
                    new PointF(x2 - w/6, y2 - h/3.5f),
                    new PointF(x2, y2)
                };
                g.DrawCurve(pen, points.ToArray(), 0.5f);
            }
            lastImage = result;
            lastImageLocation = center;
            return result;
        }
    }
}
