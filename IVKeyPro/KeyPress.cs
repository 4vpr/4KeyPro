namespace IVKeyPro
{
    public partial class Window
    {
        public void Key_Down(object sender,KeyEventArgs e)
        {
            if(e.KeyCode == Keys.D && !game.keyDown[0]){
                game.eventKeyDown[0] = true;
            }
            if(e.KeyCode == Keys.F && !game.keyDown[1]){
                game.eventKeyDown[1] = true;
            }
            if(e.KeyCode == Keys.J && !game.keyDown[2]){
                game.eventKeyDown[2] = true;
            }
            if(e.KeyCode == Keys.K && !game.keyDown[3]){
                game.eventKeyDown[3] = true;
            }
        }
        public void Key_Up(object sender,KeyEventArgs e)
        {
            if(e.KeyCode == Keys.D){
                game.eventKeyUp[0] = true;
            }
            if(e.KeyCode == Keys.F){
                game.eventKeyUp[1] = true;
            }
            if(e.KeyCode == Keys.J){
                game.eventKeyUp[2] = true;
            }
            if(e.KeyCode == Keys.K){
                game.eventKeyUp[3] = true;
            }
        }
    }
}
