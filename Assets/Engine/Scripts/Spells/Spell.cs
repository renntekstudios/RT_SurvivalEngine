using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spell : MonoBehaviour {

    public static List<SpellInfo> spellInfo = new List<SpellInfo>();

    public void AddSpell(string name, Texture texture)
    {
        SpellInfo s = new SpellInfo(name, texture);
        s.SpellName = name;
        s.SpellTexture = texture;
        spellInfo.Add(s);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddSpell("TEST", null);
        }
    }
}
