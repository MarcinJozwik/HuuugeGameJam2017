using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gamelogic.Extensions.Algorithms;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PartyCreatorController : MonoBehaviour
    {
        public LoadToRender[] Loaders;

        [SerializeField]
        private HeroGenerator heroGenerator;

        [SerializeField]
        private List<HeroModel> heroes = new List<HeroModel>();

        [SerializeField]
        private List<MeshRenderer> pedestalMats = new List<MeshRenderer>();

        [SerializeField]
        private Material pedestalActive;

        [SerializeField]
        private Material pedestalInactive;

        [SerializeField]
        private Party workingParty;

        [SerializeField]
        private AllParts allParts;


        [SerializeField]
        private Text heroDescriptionText;

        private int heroIndex = 0;

        private DescriptionGenerator descriptionGenerator;

        private Stage currentStage;


        public Stage CurrentStage
        {
            get
            {
                return this.currentStage;
            }
            set
            {
                this.currentStage = value;

                switch (currentStage)
                {
                    case Stage.Head:
                        this.LoadParts();
                        break;
                    case Stage.Torso:
                        this.LoadParts();
                        break;
                    case Stage.Class:
                        //ReloadUI
                        break;
                }
            }
        }

        public enum Stage
        {
            Head,
            Torso,
            Class
        }

        private void Awake()
        {
            this.descriptionGenerator = new DescriptionGenerator();
        }

        public void Update()
        {
            if (GameController.Instance.CurrentGameState == GameController.GameState.CreatingParty)
            {
                this.pedestalMats[this.heroIndex].material = this.pedestalActive;
            }

            if (GameController.Instance.CurrentGameState != GameController.GameState.CreatingParty)
            {
                return;   
            }

            if (CurrentStage == Stage.Class)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    ChangePart(null, null);
                    Debug.Log("User input: Q");
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    ChangePart(null, null);

                    Debug.Log("User input: W");
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    ChangePart(null, null);

                    Debug.Log("User input: E");
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    ChangePart(null, null);

                    Debug.Log("User input: R");
                }
                else if (Input.GetKeyDown(KeyCode.T))
                {
                    ChangePart(null, null);

                    Debug.Log("User input: T");
                }

                return;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangePart(this.Loaders[0].currentModel.mesh, this.Loaders[0].currentModel.material);
                Debug.Log("User input: Q");
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                ChangePart(this.Loaders[1].currentModel.mesh, this.Loaders[1].currentModel.material);

                Debug.Log("User input: W");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                ChangePart(this.Loaders[2].currentModel.mesh, this.Loaders[2].currentModel.material);

                Debug.Log("User input: E");
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                ChangePart(this.Loaders[3].currentModel.mesh, this.Loaders[3].currentModel.material);

                Debug.Log("User input: R");
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                ChangePart(this.Loaders[4].currentModel.mesh, this.Loaders[4].currentModel.material);

                Debug.Log("User input: T");
            }
        }

        public void ChangePart(Mesh mesh, Material material)
        {
            switch (CurrentStage)
            {
                case Stage.Head:
                    this.workingParty.Heroes[this.heroIndex].Head.MyModel = mesh;
                    this.workingParty.Heroes[this.heroIndex].Head.MyMaterial = material;
                    UpdateHero();
                    this.CurrentStage = Stage.Torso;
                    break;
                case Stage.Torso:
                    this.workingParty.Heroes[this.heroIndex].Torso.MyModel = mesh;
                    this.workingParty.Heroes[this.heroIndex].Torso.MyMaterial = material;
                    UpdateHero();
                    this.CurrentStage = Stage.Class;
                    break;
                case Stage.Class:

                    if (this.heroIndex < this.heroes.FindAll(model => model.ParentGameObject.active).Count - 1)
                    {
                        Party targetParty = this.heroGenerator.TargetParty;
                        this.pedestalMats[this.heroIndex].material = this.pedestalInactive;
                        this.heroIndex++;
                        this.pedestalMats[this.heroIndex].material = this.pedestalActive;
                        CurrentStage = Stage.Head;
                        this.heroDescriptionText.text = this.descriptionGenerator.GetDescription(targetParty.Heroes[this.heroIndex]);
                    }
                    else
                    {
                        GameController.Instance.CurrentGameState = GameController.GameState.CheckingResult;
                        this.pedestalMats[this.heroIndex].material = this.pedestalInactive;
                        this.heroIndex = 0;
                    }

                    break;
            }
        }

        private void UpdateHero()
        {
            this.heroes[this.heroIndex].HeadMeshFilter.mesh = this.workingParty.Heroes[this.heroIndex].Head.MyModel;
            this.heroes[this.heroIndex].HeadMeshRenderer.material = this.workingParty.Heroes[this.heroIndex].Head.MyMaterial;

            this.heroes[this.heroIndex].TorsoMeshFilter.mesh = this.workingParty.Heroes[this.heroIndex].Torso.MyModel;
            this.heroes[this.heroIndex].TorsoMeshRenderer.material = this.workingParty.Heroes[this.heroIndex].Torso.MyMaterial;        
        }

        public void ResetHeroes()
        {
            for (int i = 0; i < this.heroes.Count; i++)
            {
                this.heroes[i].HeadMeshRenderer.material = null;
                this.heroes[i].HeadMeshFilter.mesh = null;

                this.heroes[i].TorsoMeshRenderer.material = null;
                this.heroes[i].TorsoMeshFilter.mesh = null;

                this.heroes[i].ParentGameObject.SetActive(false);
            }
        }

        public void PrepareHeroes()
        {
            Party targetParty = this.heroGenerator.TargetParty;

            for (int i = 0; i < targetParty.Heroes.FindAll(hero => hero.IsActive).Count; i++)
            {
                this.heroes[i].ParentGameObject.SetActive(true);
            }

            this.CurrentStage = Stage.Head;
            this.heroDescriptionText.text = this.descriptionGenerator.GetDescription(targetParty.Heroes[this.heroIndex]);
        }

        public void LoadParts()
        {
            Party targetParty = this.heroGenerator.TargetParty;

            var list = new List<Model>();
            Model targetModel;
            switch (CurrentStage)
            {
                case Stage.Head:
                    targetModel = targetParty.Heroes[this.heroIndex].GetHead();
                    list.Add(targetModel);
                    do
                    {
                        var model = allParts.GetRandomHeadModel();
                        if (!ContainsModel(list, model))
                        {

                            list.Add(model);
                        }
                    }
                    while (list.Count != 5);
                    list.Shuffle();
                    for (int i = 0; i < 5; i++)
                    {
                        Loaders[i].LoadModel(list[i], true);
                    }
                    break;
                case Stage.Torso:
                    targetModel = targetParty.Heroes[this.heroIndex].GetTorso();
                    list.Add(targetModel);
                    do
                    {
                        var model = allParts.GetRandomTorsoModel();
                        if (!ContainsModel(list, model))
                        {

                            list.Add(model);
                        }
                    }
                    while (list.Count != 5);
                    list.Shuffle();
                    for (int i = 0; i < 5; i++)
                    {
                        Loaders[i].LoadModel(list[i], false);
                    }
                    break;
            }      


        }

        private bool IsModelTheSame(Model model1, Model model2)
        {
            return model1.material == model2.material && model1.mesh == model2.mesh;
        }

        private bool ContainsModel(List<Model> models, Model model)
        {
            foreach (var exmod in models)
            {
                if (IsModelTheSame(exmod, model))
                    return true;
            }

            return false;
        }

    }
}
