using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : Singleton<CombatManager>
{
    public CombatManager()
    {
        permanent = false;
    }

    [SerializeField] private CharacterMiniprofilesHolderUI miniprofilesHolderUI;
    [SerializeField] private CombatTimelineUI combatTimelineUI;

    public int turnCount { get; protected set; }

    public enum characterAlegiance
    {
        player,
        allied,
        hostile
    }

    

    public Dictionary<Character, characterAlegiance> charactersInCombat = new Dictionary<Character, characterAlegiance>();
    public List<Character> charactersByTurn;

    public override void OnInit()
    {
        Init();
    }

    public void Init()
    {
        Debug.Log("Combat Manager Init");

        turnCount = 0;

        if (miniprofilesHolderUI)
        {
            miniprofilesHolderUI.RemoveAllProfiles();

            foreach(Character character in charactersInCombat.Keys)
            {
                if (charactersInCombat[character] == characterAlegiance.player)
                {
                    miniprofilesHolderUI.AddProfile(character);
                }
            }
        }

        SetNextTurn();
    }

    public void SetNextTurn()
    {
        turnCount++;
        if (charactersByTurn == null)
        {
            charactersByTurn = new List<Character>();
        }

        foreach (Character character in charactersInCombat.Keys)
        {
            if (charactersInCombat[character] == characterAlegiance.player)
            {
                charactersByTurn.Add(character);
            }
        }

        charactersByTurn = charactersByTurn.OrderByDescending(a => a._base.baseStats.speed).ToList();

        if (combatTimelineUI != null)
        {
            combatTimelineUI.RemoveAllProfiles();

            foreach (Character character in charactersByTurn)
            {
                combatTimelineUI.AddProfile(character);
            }
        }
    }
}
