namespace IVKeyPro
{
    public partial class Game{
        public Note CreateNote(int a , int b , int c)
        {
                return new Note
                {
                timing = a,
                length = b,
                line = c,
                };
        }
    }
    public class Note
    {
        public int timing;
        public int line;
        public int length;

        public void Debug(){
            Console.WriteLine("timing" + timing + "line" + line + "length" + length);
        }
    }
}