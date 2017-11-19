using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts
{
    public class PartyCreatorController : MonoBehaviour
    {
        [SerializeField]
        private Party targetParty;

        [SerializeField]
        private Party workingParty;

        private void Update()
        {
            if (GameController.Instance.CurrentGameState != GameController.GameState.CreatingParty)
            {
                return;   
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("User input: Q");
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("User input: W");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("User input: E");
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("User input: R");
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("User input: T");
            }

        }
    }
}
