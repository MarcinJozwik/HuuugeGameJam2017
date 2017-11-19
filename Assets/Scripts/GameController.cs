// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="GameController.cs" company="Mr Lizard">
// //   Copyright @ 2017 Mr Lizard. All rights reserved.
// // </copyright>
// // <summary>
// //   
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using Assets.Scripts;

using Gamelogic.Extensions;

using UnityEngine;

public class GameController : Singleton<GameController>
{
    public enum GameState
    {
        InStartScreen,

        Intro,

        CreatingParty,

        CheckingResult,

        GameOver
    }

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

            switch (this.currentGameState)
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
                    this.partyTimer = 0.0f;
                    break;
                case GameState.GameOver:
                    this.GameCanvas.SetActive(false);
                    this.RestartCanvas.SetActive(true);
                    this.scoreController.ResetScore();
                    break;
            }
        }
    }

    public GameObject RestartCanvas;

    public GameObject GameCanvas;

    private GameState currentGameState;

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

    public AudioSource AudioSource;

    public AudioClip GoldSound;

    public float partyTimer;

    public readonly float createPartyTime = 100f;

    private readonly int partsPerHero = 4;

    // Use this for initialization
    private void Start()
    {
        this.CurrentGameState = GameState.InStartScreen;
    }

    // Update is called once per frame
    private void Update()
    {
        switch (this.CurrentGameState)
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
                int numberOfTotalParts = heroesInParty * this.partsPerHero;
                int wrongPartsNumber = numberOfTotalParts - wellPlacedParts;
                Debug.Log("Good choices: " + wellPlacedParts + ",Bad choices: " + wrongPartsNumber);
                this.scoreController.GenerateScore(wellPlacedParts, wrongPartsNumber);

                if (wellPlacedParts > wrongPartsNumber)
                {
                    this.AudioSource.PlayOneShot(this.GoldSound);
                }
                if (this.CurrentGameState != GameState.GameOver)
                {
                    this.CurrentGameState = GameState.Intro;
                }
                break;
            case GameState.GameOver:
                    this.partyCreatorController.ResetHeroes();
                break;
        }
    }
}