using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Mesh2Word
{



    private static Dictionary<string, string> M2W = new Dictionary<string, string>
    {
        {"Glowa_Dziula", "dziuła" },
        {"Glowa_Kokorhel", "kokorhel" },
        {"Glowa_Klobuk", "klobuk" },
        {"Glowa_Nawaz", "nawąz" },
        {"Glowa_Slojerz", "slojerz" },
        {"Glowa_Szarstuch", "szarstuch" },
        {"Glowa_Kiczka", "kiczka"},
        {"Glowa_Serpanek", "serpanek" },
        {"Glowa_Szlapa", "szlapa" },
        {"Glowa_Zatykadlnica", "zatykadlnica" },



        {"Korpus_Chechel", "czecheł" },
        {"Korpus_Kirys", "kirys" },
        {"Korpus_Napirsnik", "napirsnik" },
        {"Korpus_Rucho", "rucho" },
        {"Korpus_Wapanrok", "wapanrok"},
        {"Korpus_Kabat", "kabat"},
        {"Korpus_Kitel", "kitel" },
        {"Korpus_Mrzeincz", "mrzeincz" },
        {"Korpus_Rzyza", "rzyza" },
        {"Korpus_Tancmantlik", "Tancmantlik" }
    };

    public static string GetName(string name)
    {
        string res = "";
        M2W.TryGetValue(name, out res);
        if (res == "")
            Debug.LogError("NO SUCH NAME: " + name);

        return res;
    }
}

