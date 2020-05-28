using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace BacteriaDestruction.LeaderBoards
{
    public class LeaderBoard : MonoBehaviour
    {
        [SerializeField] private int maxLeaderBoardEntries = 4;
        [SerializeField] private Transform leaderBoardHolderTransform = null;
        [SerializeField] private GameObject leaderBoardEntryObject = null;

        [Header("Test")]
        [SerializeField] LeaderBoardEntryData testEntryData = new LeaderBoardEntryData();

        private string SavePath => $"{Application.persistentDataPath}/highscores.json";

        private void Start()
        {
            LeaderBoardSaveData savedScores = GetSavedScores();

            UpdateUI(savedScores);
        }
        [ContextMenu("Add test entry")]
        public void AddTestEntry()
        {
            AddEntry(testEntryData); 
        }

        public void AddEntry(LeaderBoardEntryData leaderBoardEntryData)
        {
            LeaderBoardSaveData savedScores = GetSavedScores();

            bool scoreAdded = false; 

            for( int i = 0; i < savedScores.highscores.Count; i++)
            {
                if(leaderBoardEntryData.enrtyScore > savedScores.highscores[i].enrtyScore)
                {
                    savedScores.highscores.Insert(i, leaderBoardEntryData);
                    scoreAdded = true;
                    break; 
                }
            }

            if(!scoreAdded && savedScores.highscores.Count < maxLeaderBoardEntries)
            {
                savedScores.highscores.Add(leaderBoardEntryData);
            }

            if(savedScores.highscores.Count > maxLeaderBoardEntries)
            {
                savedScores.highscores.RemoveRange(maxLeaderBoardEntries, savedScores.highscores.Count - maxLeaderBoardEntries);
            }

            UpdateUI(savedScores);

            SaveScores(savedScores); 
        }

        private void UpdateUI(LeaderBoardSaveData savedScores)
        {
            foreach(Transform child in leaderBoardHolderTransform)
            {
                Destroy(child.gameObject);
            }

            foreach(LeaderBoardEntryData highscore in savedScores.highscores)
            {
                Instantiate(leaderBoardEntryObject, leaderBoardHolderTransform).GetComponent<LeaderBoardEntryUI>().Initialise(highscore); 
            }
        }

        private LeaderBoardSaveData GetSavedScores()
        {
            if(!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new LeaderBoardSaveData(); 
            }

            using (StreamReader strem = new StreamReader(SavePath))
            {
                string json = strem.ReadToEnd();
                return JsonUtility.FromJson<LeaderBoardSaveData>(json); 
            }
        }

        private void SaveScores(LeaderBoardSaveData leaderBoardSaveData)
        {
            using(StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(leaderBoardSaveData, true);
                stream.Write(json);
            }
        }
    }
}

