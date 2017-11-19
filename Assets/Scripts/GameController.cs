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
        InStartScreen,
        Intro,
        CreatingParty,
        CheckingResult,
        GameOver
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
            //Debug.Log("Changing game state: " + this.currentGameState);

            switch (currentGameState)
            {
                case GameState.Intro:
                    this.GameCanvas.SetActive(true);
                    this.workingParty.Reset();
                    this.targetParty.Reset();
                    this.heroGenerator.GenerateParty(Random.Range(1, 5));
                    this.partyCreatorController.ResetHeroes();
                    this.partyCreatorController.PrepareHeroes();
                    this.CurrentGameState = GameState.CreatingParty;
                    break;
                case GameState.CreatingParty:
                    break;
                case GameState.CheckingResult:
                    break;
                case GameState.GameOver:
                    this.GameCanvas.SetActive(false);
                    this.RestartCanvas.SetActive(true);
                    this.scoreController.ResetScore();
                    break;
            }
        }
    }

    [SerializeField]
    private HeroGenerator heroGenerator;


    [SerializeField]
    private Party targetParty;

    [SerializeField]
    private Party workingParty;

    [SerializeField]
    private MatchableObject basicObject;

    [SerializeField]
    private ScoreController scoreController;

    [SerializeField]
    private PartyCreatorController partyCreatorController;

    public GameObject RestartCanvas;
    public GameObject GameCanvas;


    private float partyTimer = 0f;

    private float createPartyTime = 100f;

    private int partsPerHero = 4;

    // Use this for initialization
    void Start ()
    {
        CurrentGameState = GameState.InStartScreen;
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
                int heroesInParty = this.heroGenerator.TargetParty.Heroes.FindAll(hero => hero.IsActive).Count;

                int wellPlacedParts = this.heroGenerator.TargetParty.CompareTo(this.workingParty);
                int numberOfTotalParts = heroesInParty * partsPerHero;
                int wrongPartsNumber = numberOfTotalParts - wellPlacedParts;
                Debug.Log("Good choices: " + wellPlacedParts + ",Bad choices: " + wrongPartsNumber);
                this.scoreController.GenerateScore(wellPlacedParts, wrongPartsNumber);
                this.CurrentGameState = GameState.Intro;
                break;
        }
    }
}
