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
        {"Glowa_Nawaz", "nawaz" },
        {"Glowa_Slojerz", "slojerz" },
        {"Glowa_Szarstuch", "szarstuch" },
        {"Korpus_Chechel", "czecheł" },
        {"Korpus_Kirys", "kirys" },
        {"Korpus_Napirsnik", "napirsnik" },
        {"Korpus_Rucho", "rucho" },
        {"Korpus_Wapanrok", "wapanrok"}
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

