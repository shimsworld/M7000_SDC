using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using MoveGraphLibrary;

namespace RectangleGeneral
{
    // ******************************************
    public class RectangleGeneral : GraphicalObject
    {
        Rectangle rc;
       
        Resizing resize;
        int wMin, wMax, hMin, hMax;
        int radius;
        int halfstrip;
        SolidBrush brush;
        int selPos;
        //Brush brush;
       // Label title;
        TextMR title;

        int minsize = 25;

        // -------------------------------------------------
        public RectangleGeneral(Rectangle rect, RectRange range, int rad, int half, Color color)
        {
            rc = new Rectangle(rect.X, rect.Y, Math.Max(minsize, rect.Width), Math.Max(minsize, rect.Height));
           
            if (range == null)
            {
                wMin = wMax = rc.Width;
                hMin = hMax = rc.Height;
            }
            else
            {
                wMin = Math.Max(minsize, Math.Min(rc.Width, range.MinWidth));
                wMax = Math.Max(rc.Width, range.MaxWidth);
                hMin = Math.Max(minsize, Math.Min(rc.Height, range.MinHeight));
                hMax = Math.Max(rc.Height, range.MaxHeight);
            }


           // new TextMR(this, new Point(60, hMax / 2), txt,new Font("Microsoft Sans Serif", 22, FontStyle.Bold), Color.Magenta);
           // title = new Label();
           // title.Location = new System.Drawing.Point(wMax - wMin, hMax - hMin);
           //// title.Size = new System.Drawing.Size(100, 50);
           // title.Text = txt;
           // title.Font = new Font("Times New Roman", 12, FontStyle.Italic,GraphicsUnit.Pixel);
           // title.ForeColor = Color.Black;
           // title.Visible = true;
           // title.AutoSize = true;
           

           
            
                    RectRange realrange = new RectRange(wMin, wMax, hMin, hMax);
            resize = realrange.Resizing;

            radius = rad;
            halfstrip = half;
            brush = new SolidBrush(color);
           // brush = new Brush;
        }
        //------------------------------
        //public void Location(int x, int y)
        //{
        //      rc.X = x;
        //    rc.Y = y;
        //}
        //public void Size(int nW, int nH)
        //{
        //    rc.Width = nW;
        //    rc.Height = nH;
        //}

        // -------------------------------------------------
        public RectangleGeneral(Rectangle rect, int rad, int half, Color color)
            : this(rect, null, rad, half, color)
        {
        }
        // -------------------------------------------------        Rectangle
        public Rectangle Rectangle
        {
            get { return (rc); }
            set
            {
                rc.X = value.X;
                rc.Y = value.Y;
                rc.Height = value.Height;
                rc.Width = value.Width;
            }
        }
        //--------------------------------------------------------
        public int MouseSelPos
        {
            get { return (selPos); }
        }
        // -------------------------------------------------        Radius
        public int Radius
        {
            get { return (radius); }
            set
            {
                radius = Math.Abs(value);
                DefineCover();
            }
        }
        // -------------------------------------------------        HalfStrip
        public int HalfStrip
        {
            get { return (halfstrip); }
            set
            {
                halfstrip = Math.Abs(value);
                DefineCover();
            }
        }
        // -------------------------------------------------
        public void Draw(Graphics grfx)
        {
            grfx.FillRectangle(brush, rc);
                               
        }
        // -------------------------------------------------        Resizing
        public Resizing Resizing
        {
            get { return (resize); }
            set
            {
                resize = value;
                DefineCover();
            }
        }
        // -------------------------------------------------        DefineCover
        public override void DefineCover()
        {
            cover = new Cover(rc, resize, radius, halfstrip);
        }
        // -------------------------------------------------
        public override void Move(int cx, int cy)
        {
            rc.X += cx;
            rc.Y += cy;
          

        }

        public  void Location(int x, int y)
        {
            rc.X = x;
            rc.Y = y;
        }

        public  void Size(int w, int h)
        {
            rc.Height = h;
            rc.Width = w;
        }

        // -------------------------------------------------        MoveNode
        public override bool MoveNode(int i, int cx, int cy, Point ptM, MouseButtons mb)
        {
            bool bRet = false;

            selPos = i;

            if (mb == MouseButtons.Left)
            {
                int dxNew, dyNew;
                switch (resize)
                {
                    case Resizing.Any:
                        if (i == 8)
                        {
                            Move(cx, cy);
                        }
                        else if (i == 0)        //LT corner
                        {
                            dyNew = rc.Height - cy;
                            if (hMin <= dyNew && dyNew <= hMax)
                            {
                                MoveBorder_Top(cy);
                                bRet = true;
                            }
                            dxNew = rc.Width - cx;
                            if (wMin <= dxNew && dxNew <= wMax)
                            {
                                MoveBorder_Left(cx);
                                bRet = true;
                            }
                        }
                        else if (i == 1)        // RT corner
                        {
                            dyNew = rc.Height - cy;
                            if (hMin <= dyNew && dyNew <= hMax)
                            {
                                MoveBorder_Top(cy);
                                bRet = true;
                            }
                            dxNew = rc.Width + cx;
                            if (wMin <= dxNew && dxNew <= wMax)
                            {
                                MoveBorder_Right(cx);
                                bRet = true;
                            }
                        }
                        else if (i == 2)        // RB corner
                        {
                            dxNew = rc.Width + cx;
                            if (wMin <= dxNew && dxNew <= wMax)
                            {
                                MoveBorder_Right(cx);
                                bRet = true;
                            }
                            dyNew = rc.Height + cy;
                            if (hMin <= dyNew && dyNew <= hMax)
                            {
                                MoveBorder_Bottom(cy);
                                bRet = true;
                            }
                        }
                        else if (i == 3)        // LB corner
                        {
                            dyNew = rc.Height + cy;
                            if (hMin <= dyNew && dyNew <= hMax)
                            {
                                MoveBorder_Bottom(cy);
                                bRet = true;
                            }
                            dxNew = rc.Width - cx;
                            if (wMin <= dxNew && dxNew <= wMax)
                            {
                                MoveBorder_Left(cx);
                                bRet = true;
                            }
                        }
                        else if (i == 4)     // on left side
                        {
                            dxNew = rc.Width - cx;
                            if (wMin <= dxNew && dxNew <= wMax)
                            {
                                MoveBorder_Left(cx);
                                bRet = true;
                            }
                        }
                        else if (i == 5)   // on right side
                        {
                            dxNew = rc.Width + cx;
                            if (wMin <= dxNew && dxNew <= wMax)
                            {
                                MoveBorder_Right(cx);
                                bRet = true;
                            }
                        }
                        else if (i == 6)      // on top
                        {
                            dyNew = rc.Height - cy;
                            if (hMin <= dyNew && dyNew <= hMax)
                            {
                                MoveBorder_Top(cy);
                                bRet = true;
                            }
                        }
                        else if (i == 7)   // on bottom
                        {
                            dyNew = rc.Height + cy;
                            if (hMin <= dyNew && dyNew <= hMax)
                            {
                                MoveBorder_Bottom(cy);
                                bRet = true;
                            }
                        }
                        break;

                    case Resizing.NS:
                        if (i == 2)
                        {
                            Move(cx, cy);
                        }
                        else if (i == 0)      // on top
                        {
                            dyNew = rc.Height - cy;
                            if (hMin <= dyNew && dyNew <= hMax)
                            {
                                MoveBorder_Top(cy);
                                bRet = true;
                            }
                        }
                        else if (i == 1)   // on bottom
                        {
                            dyNew = rc.Height + cy;
                            if (hMin <= dyNew && dyNew <= hMax)
                            {
                                MoveBorder_Bottom(cy);
                                bRet = true;
                            }
                        }
                        break;

                    case Resizing.WE:
                        if (i == 2)
                        {
                            Move(cx, cy);
                        }
                        else if (i == 0)     // on left side
                        {
                            dxNew = rc.Width - cx;
                            if (wMin <= dxNew && dxNew <= wMax)
                            {
                                MoveBorder_Left(cx);
                                bRet = true;
                            }
                        }
                        else if (i == 1)   // on right side
                        {
                            dxNew = rc.Width + cx;
                            if (wMin <= dxNew && dxNew <= wMax)
                            {
                                MoveBorder_Right(cx);
                                bRet = true;
                            }
                        }
                        break;

                    case Resizing.None:
                        Move(cx, cy);
                        break;
                }
            }
            else if (mb == MouseButtons.Right)
            {

                Move(cx, cy);

            }
            return (bRet);
        }
        // -------------------------------------------------        MoveBorder_Top
        private void MoveBorder_Top(int cy)
        {
            rc.Y += cy;
            rc.Height -= cy;
        }
        // -------------------------------------------------        MoveBorder_Bottom
        private void MoveBorder_Bottom(int cy)
        {
            rc.Height += cy;
        }
        // -------------------------------------------------        MoveBorder_Left
        private void MoveBorder_Left(int cx)
        {
            rc.X += cx;
            rc.Width -= cx;
        }
        // -------------------------------------------------        MoveBorder_Right
        private void MoveBorder_Right(int cx)
        {
            rc.Width += cx;
        }

  

    }
}
