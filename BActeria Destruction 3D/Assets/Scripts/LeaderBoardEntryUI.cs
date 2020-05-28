
using TMPro;
using UnityEngine;

namespace BacteriaDestruction.LeaderBoards
{
    public class LeaderBoardEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entryNameText = null;
        [SerializeField] private TextMeshProUGUI entryScoreText = null;

        public void Initialise(LeaderBoardEntryData leaderBoardEntryData )
        {
            entryNameText.text = leaderBoardEntryData.enrtyName;
            entryScoreText.text = leaderBoardEntryData.enrtyScore.ToString();
        }
    }
}

