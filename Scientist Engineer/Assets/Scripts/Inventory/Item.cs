using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Basic Information")]
    public int ID;
    public Sprite Icon;
    public string ItemName;
    [TextArea] public string Description;

    [Header("Additional Info")]
    public bool isAmmo;
    public bool isWeapon;
}
