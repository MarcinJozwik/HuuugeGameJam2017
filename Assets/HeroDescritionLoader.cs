using UnityEngine;
using UnityEngine.UI;

public class HeroDescritionLoader : MonoBehaviour {

    public Text text;

    public void SetHeroDescription(string heroDesc)
    {
        text.text = heroDesc;
    }
	
}
