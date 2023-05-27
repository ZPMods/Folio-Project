using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTimelineUI : MonoBehaviour
{
    public GameObject characterTimelineIconPrefab;
    public HorizontalOrVerticalLayoutGroup iconsHolder;

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
        if (iconsHolder != null && iconsHolder.transform.childCount > 0)
        {
            for (int i = iconsHolder.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(iconsHolder.transform.GetChild(i).gameObject);
            }
        }
    }

    public void AddProfile(Character character)
    {
        if (iconsHolder != null || iconsHolder != null)
        {
            GameObject newProfile = Instantiate(characterTimelineIconPrefab, iconsHolder.transform);
            if (newProfile.TryGetComponent(out CombatTimelineIconUI miniprofileUI))
            {
                miniprofileUI.LinkCharacter(character);
            }

            else
            {
                Debug.Log("No CombatTimelineIconUI component found.");
            }
        }
    }
}
