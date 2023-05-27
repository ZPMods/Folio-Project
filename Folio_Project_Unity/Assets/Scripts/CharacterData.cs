using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterResource
{
    None,
    Mana,
    Stamina,
    Armor
}

[System.Serializable]
public struct CharacterStats
{
    public float fullHealth;

    public float damage;
    public float magicDamage;

    public float physicalDef;
    public float magicalDef;

    public CharacterResource resourceType;
    public float fullResource;

    public float speed;
}

[System.Serializable]
public class Character
{
    public CharacterBase _base;

    [SerializeField]
    private float _health;
    public float health
    {
        get
        {
            return Mathf.Clamp(_health, 0, _base.baseStats.fullHealth);
        }
    }
}