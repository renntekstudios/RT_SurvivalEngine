using UnityEngine;
using System.Collections;

[System.Serializable]
public class SpellInfo {

    public string SpellName;
    public Texture SpellTexture;

    public SpellInfo(string name, Texture texture)
    {
        name = SpellName;
        texture = SpellTexture;
    }
}
