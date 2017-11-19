using System;
using System.Collections;
using System.Collections.Generic;

using Assets.Scripts;

using Gamelogic.Extensions;

using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class GameController : Singleton<GameController> {

    public enum GameState
    {
        Intro,
        CreatingParty,
        CheckingResult,
    }

    private GameState currentGameState;
    public GameState CurrentGameState
    {
        get
        {
            return this.currentGameState;
        }

        set
        {
            this.currentGameState = value;
            Debug.Log("Changing game state: " + this.currentGameState);

            switch (currentGameState)
            {
                case GameState.Intro:
                    this.heroGenerator.GenerateParty(Random.Range(0, 4));
                    this.heroDescriptionText.text = "dupa";
                    this.CurrentGameState = GameState.CreatingParty;
                    break;
                case GameState.CreatingParty:
                    break;
                case GameState.CheckingResult:
                    break;
            }
        }
    }

    [SerializeField]
    private HeroGenerator heroGenerator;

    [SerializeField]
    private Text heroDescriptionText;

    [SerializeField]
    private Party targetParty;

    [SerializeField]
    private Party workingParty;

    [SerializeField]
    private ScoreController scoreController;

    private float partyTimer = 0f;

    private float createPartyTime = 10f;

    private int partsPerHero = 4;

    // Use this for initialization
	void Start ()
	{
	    CurrentGameState = GameState.Intro;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (CurrentGameState)
        {
            case GameState.Intro:
                break;
            case GameState.CreatingParty:

                if (this.partyTimer >= this.createPartyTime)
                {
                    this.CurrentGameState = GameState.CheckingResult;
                    this.partyTimer = 0f;
                }
                else
                {
                    this.partyTimer += Time.deltaTime;
                }

                break;
            case GameState.CheckingResult:
                int heroesInParty = this.targetParty.Heroes.FindAll(hero => hero.IsActive).Count;

                int wellPlacedParts = this.targetParty.CompareTo(this.workingParty);
                int numberOfTotalParts = heroesInParty * partsPerHero;
                int wrongPartsNumber = numberOfTotalParts - wellPlacedParts;
                this.scoreController.GenerateScore(wellPlacedParts, wrongPartsNumber);
                this.CurrentGameState = GameState.Intro;
                break;
        }
	}
}
