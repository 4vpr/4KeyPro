using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Data;
using System;
using System.IO;
using System.Collections.Generic;

namespace IVKeyPro
{
    public partial class Game
    {
        Note nullNote = new Note ();
        public bool ingame = true;
        // true while playing game
        
        int[] longnote = {0,0,0,0};
        // the length of 'in judgment' note

    
        int chunkCount = 0; int chunkLength = 1000;


        List<Note> note = new List<Note> ();
        public List<Note> spawnedNote = new List<Note> ();


        public float notevelocity = 1.5f;
        // the speed of notes

        //double[] test = {300,300,300,300};


        /* keys */ public bool[] keydown = {false,false,false,false};
        /* keys */ public bool[] keyre = {false,false,false,false};
        /* keys */ public bool[] keyup = {true,true,true,true};
        double score; int combo;
        //double hscore;
        int delay = 0;
        int noteCount = 0; public double ms = 0; double starttime;
        //int[,] note = new int[50000,3];
        double[] acc = {300,300,300,300}; Note[] nextnote = new Note[4];
        string? songtitle; string? songartist;

    }
}