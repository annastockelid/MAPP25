
using System;
using System.Collections.Generic;


namespace BacteriaDestruction.LeaderBoards
{
    [Serializable]
    public class LeaderBoardSaveData 
    {
        public List<LeaderBoardEntryData> highscores = new List<LeaderBoardEntryData>();
    }

}

