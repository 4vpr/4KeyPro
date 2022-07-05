using System.Security.AccessControl;
namespace IVKeyPro
{
    // Update , UpdateLine , UpdateAcc
    public partial class Game
    {
        public void Update (double n){
            ms = ((n - starttime) / 1000000) - delay - 1000;
            UpdateChunk();
            UpdateAcc();
            //DoLongNote();
        }

        public void DoLongNote(){
            for(int i = 0;i<4;i++){
                if(longnote[i] != 0){
                    acc[i] = longnote[i] - ms;
                    if(keydown[i] == false){
                        if(acc[i] < 27 && acc[i] > -27){
                            UpdateLine(nextnote[i]);
                            Judgement(1);
                        } else if(acc[i] < 54 && acc[i] > -54){
                            UpdateLine(nextnote[i]);
                            Judgement(2);

                        }else if(acc[i] < 105 && acc[i] > -105){
                            UpdateLine(nextnote[i]);
                            Judgement(3);

                        }else if(acc[i] < 150 && acc[i] > -150){
                            UpdateLine(nextnote[i]);
                            Judgement(4);

                        }else if(acc[i] < 300 && longnote[i] != 0){
                            UpdateLine(nextnote[i]);
                            Judgement(0);
                        }

                        if (acc[i] > 300){
                        UpdateLine(nextnote[i]);
                        Judgement(0);
                        }
                    }
                }
            }






        }
        public void UpdateLine (Note prevnote)
        {
            spawnedNote.Remove(prevnote);
            longnote[prevnote.line] = 0;
            foreach (var item in spawnedNote)
            {
                if(item.line == prevnote.line){
                    nextnote[prevnote.line] = item;
                    //Console.WriteLine("line" + prevnote.line + "updated");
                    if(item.length>0){
                        longnote[item.line] = item.timing + item.length;
                    }
                    break;
                }
            }
            if(prevnote == nextnote[prevnote.line]){
                nextnote[prevnote.line] = nullNote;
            }
        }
        public void UpdateLine (int i){
            bool set = false;
            foreach(var item in spawnedNote){
                if(item.line == i && set == false){
                    nextnote[i] = item;
                    //Console.WriteLine("line" + i + "updated");
                    set = true;            
                }
            }
            if(set == false){
                nextnote[i] = nullNote;
            }
        }
        public void UpdateChunk(){
            if (ms + chunkLength > chunkLength * chunkCount)
            {
                chunkCount ++;
                foreach(var item in note){
                    if(item.timing > chunkCount * chunkLength){
                        spawnedNote.Add(item);
                    }
                }
                note.RemoveAll(spawnedNote.Contains);
                for(int i = 0;i < 4;i++){UpdateLine(i);}
            }
        }

        public void UpdateAcc (){
            for(int i=0;i<4;i++){
            if(nextnote[i] != nullNote){
                    acc[i] = nextnote[i].timing - ms;
                    //acc = nextnotetime - time
                    if(acc[i] < -150){
                        //miss
                        UpdateLine(nextnote[i]);
                        Judgement(0);
                    }
                }
                else
                {
                    acc[i] = 300;
                }
                if(keydown[i] == true){
                    if(acc[i] < 25 && acc[i] > -25){
                        UpdateLine(nextnote[i]);
                        Judgement(1);
                    }
                    else if(acc[i] < 50 && acc[i] > -50){
                        UpdateLine(nextnote[i]);
                        Judgement(2);
                    }
                    else if(acc[i] < 100 && acc[i] > -100){
                        UpdateLine(nextnote[i]);
                        Judgement(3);
                    }
                    else if(acc[i] < 150 && acc[i] > -150){
                        UpdateLine(nextnote[i]);
                        Judgement(4);
                    }
                    else if(acc[i] < 300){
                        UpdateLine(nextnote[i]);
                        Judgement(0);
                    }
                }
                
            }
            keydown[0] = false; keydown[1] = false; keydown[2] = false; keydown[3] = false;
        }
        public void Judgement(int j){
            if(j != 0){
                combo ++;
            }
            if(j == 1){
                score += 100;
                Console.WriteLine("Pro+");
            }
            if(j == 2){
                score += 95;
                Console.WriteLine("Pro");
            }
            if(j == 3){
                score += 80;
                Console.WriteLine("Noob");
            }
            if(j == 4){
                score += 50;
                Console.WriteLine("Bad");
            }
            if(j == 0){
                combo = 0;
                Console.WriteLine("Miss");
            }
        }
    }
}