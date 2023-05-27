using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterMiniprofileUI : MonoBehaviour
{
    private Character linkedCharacter;



    [SerializeField]
    private Image characterIcon;
    
    [SerializeField]
    private TMP_Text characterNameLabel;

    [SerializeField]
    private Slider characterHealthSlider;

    

    public void LinkCharacter(Character character)
    {
        if (characterIcon) characterIcon.sprite = character._base.characterCombatSprite;
        if (characterNameLabel) characterNameLabel.text = character._base.characterName;
        if (characterHealthSlider) characterHealthSlider.value = character._base.baseStats.fullHealth > 0 ? character.health / character._base.baseStats.fullHealth : characterHealthSlider.minValue;
    }
}
