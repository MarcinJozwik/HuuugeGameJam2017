using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ScoreController : MonoBehaviour
    {
        private int initialGold = 100;

        private int totalScore = 0;

        private int goldPerPart = 5;

        [SerializeField]
        private Text goldCounter;

        private void Start()
        {
            this.totalScore = this.initialGold;
            this.goldCounter.text = "Twe dukaty: " + totalScore;
        }

        public void GenerateScore(int wellPlacedParts, int wrongPlacedParts)
        {

            int wrongGoldEarned = wrongPlacedParts * (-this.goldPerPart);
            int goodGoldEarned = wellPlacedParts * this.goldPerPart;

            int totalIncome = wrongGoldEarned + goodGoldEarned;

            this.totalScore += totalIncome;
            this.goldCounter.text = "Twe dukaty: " + totalScore;

            if (this.totalScore <= 0)
            {
                GameController.Instance.CurrentGameState = GameController.GameState.GameOver;
            }
        }

        public void ResetScore()
        {
            this.totalScore = this.initialGold;
            this.goldCounter.text = "Twe dukaty: " + totalScore;
        }
    }
}
