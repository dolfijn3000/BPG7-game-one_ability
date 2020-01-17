using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PropabilityTableItem", menuName = "BPG7-game/PropabilityTableItem", order = 0)]
public class PropabilityTableItem : ScriptableObject
{
    public GameObject value;
    public int propability;
}