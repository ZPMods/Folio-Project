using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct PlayerData
{
    public List<Character> playerCharacters;
}

public class GameManager : Singleton<GameManager>
{
    public GameManager()
    {
        permanent = true;
    }

    public PlayerData currentPlayerData;

    public void LoadCombatScene()
    {
        StartCoroutine(LoadCombatSceneAsync());
    }

    public IEnumerator LoadCombatSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CombatScene");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        if (CombatManager.instance != null)
        {
            foreach(Character character in currentPlayerData.playerCharacters)
            {
                CombatManager.instance.charactersInCombat.Add(character, CombatManager.characterAlegiance.player);
            }

            CombatManager.instance.Init();
        }
    }
}
