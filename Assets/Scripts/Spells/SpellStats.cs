using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellStats
{
    public Texture icon;
    public string spellName;
    public string description;
    public int id;
    public GameObject SpellPrefab;
    public float SpellFireRate;
    public float SpellRange;
    public float SpellSpeed;
    public float SpellLiveTime;


    public SpellStats(SpellStats d)
    {
        icon = d.icon;
        spellName = d.spellName;
        description = d.description;
        id = d.id;
        SpellPrefab = d.SpellPrefab;
        SpellFireRate = d.SpellFireRate;
        SpellRange = d.SpellRange;
        SpellSpeed = d.SpellSpeed;
        SpellLiveTime = d.SpellLiveTime;
    }
}
