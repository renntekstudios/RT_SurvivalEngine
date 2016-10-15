using UnityEngine;
using System.Collections;

public class SpellGUI : MonoBehaviour {

    void OnGUI()
    {

        if (Spell.spellInfo.Count > 0)
        {
            GUILayout.BeginHorizontal();
            foreach (SpellInfo spell in Spell.spellInfo)
            {
                GUILayout.Box("SPELL = " + spell);
            }
            GUILayout.EndHorizontal();
        }
      //  GUI.Box(new Rect(10, 10, S, 20), curHealth + "/" + maxHealth);
    }
}
