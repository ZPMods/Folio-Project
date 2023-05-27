using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTimelineIconUI : MonoBehaviour
{
    private Character linkedCharacter;



    [SerializeField]
    private Image characterIcon;

    public void LinkCharacter(Character character)
    {
        if (characterIcon) characterIcon.sprite = character._base.characterCombatSprite;
    }
}
