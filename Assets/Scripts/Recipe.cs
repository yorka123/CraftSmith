using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Inventory/Recipe", order = 3)]
public class Recipe : ScriptableObject
{
    public Item item1;
    public Item item2;
    public Item item3;
    public Item Result;
}
