namespace IVKeyPro
{
    public partial class Game
    {
        public bool play = true;
        public void Start(double now)
        {
            string beatmap_lo = Application.StartupPath + @"\Beatmaps";
            string beatmap_play = @"\Omaewa mou"; // TEST
                string? line; string mode = "none";
                int p1, p2 , a1 ,a2 ,a3;
                try{
                StreamReader reader = new StreamReader(beatmap_lo + beatmap_play + @"\map.b");
                
                line = reader.ReadLine();
                while (line != null)
                {
                    if(mode == "note" && line.Length > 3){
                        try
                        {
                            p1 = line.IndexOf(',');
                            p2 = line.IndexOf(',', p1 + 1);
                            a1 = Convert.ToInt32(line.Substring(0, p1));
                            a2 = Convert.ToInt32(line.Substring(p1 + 1, (p2 - p1) - 1));
                            a3 = Convert.ToInt32(line.Substring(p2 + 1));
                            if(a2 < 50 && a2 > 0){
                                a2 = 50;
                                Console.WriteLine("long note length must be > 50ms or 0ms");
                            }
                            note.Add (CreateNote(a1,a2,a3));
                            noteCount++;
                        }
                        catch
                        {
                            Console.WriteLine("Note[" + noteCount +"] doesn't fit the standard");
                            Console.WriteLine("Timing,Line,Length(0 if is not longnote)");
                        }

                    }

                    if(mode == "info"){
                        if(line.Length > 10) {
                            if(line.Substring(0,10).Equals("SongTitle:")){
                                int Starts = line.IndexOf('\"');
                                int Ends = line.IndexOf('\"', Starts + 1);
                                if(Starts != -1 && Ends != -1){
                                    songtitle = line.Substring(Starts + 1,Ends - Starts);
                                    Console.WriteLine(songtitle);
                                }
                            }
                        }
                        if(line.Length > 11) {
                            if(line.Substring(0,11).Equals("SongArtist:")){
                                int Starts = line.IndexOf('\"');
                                int Ends = line.IndexOf('\"', Starts + 1);
                                if(Starts != -1 && Ends != -1){
                                    songartist = line.Substring(Starts + 1,(Ends - Starts) - 1);
                                    Console.WriteLine(songartist);
                                }
                            }
                        }
                    }
                    if(line.Equals("[note]")) mode = "note";
                    if(line.Equals("[info]")) mode = "info";
                    starttime = now;
                    line = reader.ReadLine();
                }
                UpdateChunk();
            }catch{
                Console.WriteLine("No Beatmap Found");
                play = false;
            }
        }
    }
}