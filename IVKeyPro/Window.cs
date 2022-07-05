using System.Diagnostics;
using System.Drawing;

namespace IVKeyPro;

public partial class Window : Form
{
    #region int
        private System.ComponentModel.IContainer? components = null;
        protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1280, 720);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.Text = "4KeyPro";
    }
    #endregion int
    
    Game game = new Game();
    bool InGame;
    
    public Window()
    {
        InitializeComponent();
        Thread run = new Thread(new ThreadStart(Run)); 
        Thread draw = new Thread(new ThreadStart(Drawloop));
        run.Start();
        draw.Start();
        this.FormClosed += Close;
        this.KeyDown += Key_Down;
        this.KeyUp += Key_Up;
    }

    public void Drawloop(){
        long lastime = getns();
        double TargetFps = 240;
        double ns = 0;
        double deltatime;
        if(TargetFps != 0) ns = 1000000000 / TargetFps;
        double delta = 0;
        InGame = true;
        int fps = 0;
        long now = getns();
        long Time = getns() + 1000000000;
        while (InGame && game.ingame)
        {
            //render per second
            now = getns();
            deltatime = (now - lastime);
            lastime = now;
            if(TargetFps != 0) delta += (deltatime) / ns;
            if(delta >= 1 || ns ==0)
            {
                fps++;
                if(delta != 0)delta--;
                Draw();
            }
            if(now>Time)
            {
                Console.WriteLine(fps);
                Time += 1000000000;
                fps=0;
            }
        }
    }
    public void Run()
    {
        long lastime = getns();
        double TargetFps = 0;
        double ns = 0;
        double deltatime;
        if(TargetFps != 0) ns = 1000000000 / TargetFps;
        double delta = 0;
        InGame = true;
        int fps = 0;
        long now = getns();
        long Time = getns() + 1000000000;
        game.Start(now);
        while (InGame && game.ingame)
        {
            //update per second
            now = getns();
            deltatime = (now - lastime);
            lastime = now;
            if(TargetFps != 0) delta += (deltatime) / ns;
            if(delta >= 1 || ns ==0)
            {
                fps++;
                if(delta != 0)delta--;
                game.Update(now);
            }
            if(now>Time)
            {
                //Console.WriteLine(fps);
                Time += 1000000000;
                fps=0;
            }
        }
    }
    public void Close(Object sender,EventArgs e){
        InGame = false;
    }
    public static long getns()
    {
        double timestamp = Stopwatch.GetTimestamp();
        double nanoseconds = 1_000_000_000.0 * timestamp / Stopwatch.Frequency;
        return (long)nanoseconds;
    }
}
