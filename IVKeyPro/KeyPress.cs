namespace IVKeyPro
{
    public partial class Window
    {
        public async void Key_Down(object sender,KeyEventArgs e){
                if(e.KeyCode == Keys.D && game.keyre[0] == false){
                    game.keydown[0] = true;
                    game.keyup[0] = false;

                    game.keyre[0] = true;
                }
                if(e.KeyCode == Keys.F && game.keyre[1] == false){
                    game.keydown[1] = true;
                    game.keyup[1] = false;

                    game.keyre[1] = true;
                }
                if(e.KeyCode == Keys.J && game.keyre[2] == false){
                    game.keydown[2] = true;
                    game.keyup[2] = false;

                    game.keyre[2] = true;
                }
                if(e.KeyCode == Keys.K && game.keyre[3] == false){
                    game.keydown[3] = true;
                    game.keyup[3] = false;

                    game.keyre[3] = true;
                }
            }
        public void Key_Up(object sender,KeyEventArgs e){
                if(e.KeyCode == Keys.D){
                    game.keydown[0] = false;
                    game.keyup[0] = true;

                    game.keyre[0] = false;
                }
                if(e.KeyCode == Keys.F){
                    game.keydown[1] = false;
                    game.keyup[1] = true;

                    game.keyre[1] = false;
                }
                if(e.KeyCode == Keys.J){
                    game.keydown[2] = false;
                    game.keyup[2] = true;

                    game.keyre[2] = false;
                }
                if(e.KeyCode == Keys.K){
                    game.keydown[3] = false;
                    game.keyup[3] = true;

                    game.keyre[3] = false;
                }
        }
    }
}