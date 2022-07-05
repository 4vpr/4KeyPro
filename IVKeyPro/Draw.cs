using System.Globalization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace IVKeyPro

{
    
    public partial class Window : Form
    {
        public void DrawImage2FloatRectF(PaintEventArgs e)
        {
                    
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                    
            // Create coordinates for upper-left corner of image.
            float x = 100.0F;
            float y = 100.0F;
                    
            // Create rectangle for source image.
            RectangleF srcRect = new RectangleF(1000.0F, 300.0F, 300.0F, 150.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;
                    
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, x, y, srcRect, units);
        }

        Image img = new Bitmap(1280,720);
        Graphics g;
        public void Draw(){
            g = CreateGraphics();
            g.Clear (Color.Black);
            DoubleBuffered = true;
            SolidBrush b = new SolidBrush(Color.White);
            Rectangle rct = new Rectangle();
            Rectangle pen = new Rectangle();
            rct.Width = 100;
            rct.Height = 25;
            double besok = 2;
            try{
                foreach (var item in game.spawnedNote){
                    if(item.length == 0){
                        rct.Height = 25;
                    } else {
                        rct.Height = item.length;
                    }
                    rct.X = 100 * item.line + 200;
                    rct.Y = Convert.ToInt32(Math.Round((game.ms - item.timing) * besok + 670 - item.length));
                    g.FillRectangle(b, rct);
                }
            }
            catch{
            }
            pen.Width = 5;
            pen.Height = 960;
            pen.Y = 0;
            pen.X = 200;
            g.FillRectangle(b,pen);
            pen.Y = 0;
            pen.X = 600;
            g.FillRectangle(b,pen);
            pen.Width = 400;
            pen.Height = 5;
            pen.Y = 670;
            pen.X = 200;
            g.FillRectangle(b,pen);
            g.DrawImage(img,0,0);
        }
    }
}