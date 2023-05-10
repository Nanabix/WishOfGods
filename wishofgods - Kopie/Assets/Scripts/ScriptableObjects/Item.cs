using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//in work
[CreateAssetMenu(menuName = "Scriptable Item")]
public class Item : ScriptableObject
{
    [Header("Only Gameplay")]
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;
    public int gold;

    [Header("Both")]
    public Sprite image;
}

public enum ItemType
{
    Quest,
    Heal,
    Consumable

}

public enum ActionType
{

}
