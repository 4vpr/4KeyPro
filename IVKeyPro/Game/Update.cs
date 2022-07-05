using System.Security.AccessControl;
namespace IVKeyPro
{
    // Update , UpdateLine , UpdateAcc
    public partial class Game
    {
        public void Update (double n){
            ms = ((n - starttime) / 1000000) - delay;
            KeyCheck(true);
            UpdateChunk();
            UpdateAcc();
            DoLongNote();
            KeyCheck(false);
        }
        public void KeyCheck(bool b){
            if(b)
            {
                for(int i = 0;i<4;i++){
                    if(eventKeyDown[i]){
                        keyPress[i] = true;
                        keyDown[i] = true;
                        eventKeyDown[i] = false;
                    }
                    if(eventKeyUp[i]){
                        keyUp[i] = true;
                        eventKeyUp[i] = false;
                        Console.WriteLine("KeyUp");
                    }
                }
            }
            if(!b)
            {
                for(int i = 0;i<4;i++){
                    if(keyDown[i] && keyUp[i]){
                        keyDown[i] = false;
                    }
                    keyPress[i] = false;
                    keyUp[i] = false;
                }
            }
        }
        public void DoLongNote(){
            for(int i = 0;i<4;i++){
                if(isLongNote[i]){
                    acc_long[i] = nextnote[i].timing + nextnote[i].length - ms;
                    if(keyUp[i]){
                        if(acc_long[i] < 25 && acc_long[i] > -25){
                            CheckLongNote(i);
                            isLongNote[i] = false;
                            Judgement(1);
                        } else if(acc_long[i] < 50 && acc_long[i] > -50){
                            CheckLongNote(i);
                            isLongNote[i] = false;
                            Judgement(2);

                        }else if(acc_long[i] < 75 && acc_long[i] > 75){
                            CheckLongNote(i);
                            isLongNote[i] = false;
                            Judgement(3);

                        }else if(acc_long[i] < 100 && acc_long[i] > -100){
                            CheckLongNote(i);
                            isLongNote[i] = false;
                            Judgement(4);

                        }else if(acc_long[i] > 100){
                            CheckLongNote(i);
                            isLongNote[i] = false;
                            Console.WriteLine("reason 3");
                            Judgement(0);
                        }
                    
                    if(debug == 0){
                        debug = ms;
                        Console.WriteLine(debug);
                    }

                    if(debug + 50 < ms){
                        debug += 50;
                        Console.WriteLine("HI");
                        Console.WriteLine(acc_long[i]);
                    }

                    }
                    if (acc_long[i] < -150){
                        UpdateLine(nextnote[i]);
                        isLongNote[i] = false;
                        Console.WriteLine("reason 4");
                        Judgement(0);
                    }
                }
            }
        }
        public void UpdateLine (Note prevnote)
        {
            spawnedNote.Remove(prevnote);
            foreach (var item in spawnedNote)
            {
                if(item.line == prevnote.line){
                    nextnote[prevnote.line] = item;
                    //Console.WriteLine("line" + prevnote.line + "updated");
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
                    break;
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
                    if(item.timing < chunkCount * chunkLength){
                        spawnedNote.Add(item);
                    }
                }
                note.RemoveAll(spawnedNote.Contains);
                for(int i = 0;i < 4;i++){
                    UpdateLine(i);
                }
            }
        }
        public void CheckLongNote(int i) {
            if(nextnote[i].length > 0 && !isLongNote[i]){
                isLongNote[i] = true;
            } else {
                UpdateLine(nextnote[i]);
                isLongNote[i] = false;
            }
        }
        public void UpdateAcc (){
            for(int i=0;i<4;i++){
            if(nextnote[i] != nullNote){
                acc[i] = nextnote[i].timing - ms;
                if(acc[i] < -150 && !isLongNote[i]){
                        //miss
                        UpdateLine(nextnote[i]);
                        Console.WriteLine("reason 1");
                        Judgement(0);
                }
            }
                else
            {
                acc[i] = 1000;
            }
                if(keyPress[i]){
                    if(acc[i] < 25 && acc[i] > -25){
                        CheckLongNote(i);
                        Judgement(1);
                    }
                    else if(acc[i] < 50 && acc[i] > -50){
                        CheckLongNote(i);
                        Judgement(2);
                    }
                    else if(acc[i] < 75 && acc[i] > -75){
                        CheckLongNote(i);
                        Judgement(3);
                    }
                    else if(acc[i] < 100 && acc[i] > -100){
                        CheckLongNote(i);
                        Judgement(4);
                    }
                    else if(acc[i] < 150){
                        UpdateLine(nextnote[i]);
                        Console.WriteLine("reason 2");
                        Judgement(0);
                    }
                }
                
            }
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