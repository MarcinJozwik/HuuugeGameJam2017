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

        private int goldPerPart = 20;

        [SerializeField]
        private Text goldCounter;


        public void GenerateScore(int wellPlacedParts, int wrongPlacedParts)
        {

            int wrongGoldEarned = wrongPlacedParts * (-this.goldPerPart);
            int goodGoldEarned = wellPlacedParts * this.goldPerPart;

            int totalIncome = wrongGoldEarned + goodGoldEarned;
            this.goldCounter.text = "Your gold: " + totalIncome;
        }
    }
}
