using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Class", menuName = "ZPMods/Characters/Character Class", order = 1)]
public class CharacterBase : ScriptableObject
{
    public string characterName;

    public string characterDescription;

    public Sprite characterCombatSprite;
    public Sprite characterIconSprite;

    public CharacterStats baseStats;
}
