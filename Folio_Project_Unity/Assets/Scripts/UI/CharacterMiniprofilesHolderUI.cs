using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMiniprofilesHolderUI : MonoBehaviour
{
    public HorizontalOrVerticalLayoutGroup profilesHolder;

    public GameObject miniprofilePrefab;

    public void SetProfiles(Character[] characters)
    {
        if (CombatManager.instance != null)
        {
            RemoveAllProfiles();

            foreach (Character character in characters)
            {
                AddProfile(character);
            }
        }

        else
        {
            Debug.Log("No Game Manager found.");
        }
    }

    public void RemoveAllProfiles()
    {
        if (profilesHolder != null && profilesHolder.transform.childCount > 0)
        {
            for (int i = profilesHolder.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(profilesHolder.transform.GetChild(i).gameObject);
            }
        }
    }

    public void AddProfile(Character character)
    {
        if (profilesHolder != null || miniprofilePrefab != null)
        {
            GameObject newProfile = Instantiate(miniprofilePrefab, profilesHolder.transform);
            if (newProfile.TryGetComponent(out CharacterMiniprofileUI miniprofileUI))
            {
                miniprofileUI.LinkCharacter(character);
            }

            else
            {
                Debug.Log("No CharacterMiniprofileUI component found.");
            }
        }
    }
}
