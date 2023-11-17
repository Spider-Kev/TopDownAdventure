using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region INTERFACES
/// <summary>
/// Interact with playerInteractionSystem
/// </summary>
public interface IInteractable
{
    void Interact();

}

/// <summary>
/// Allows for receive damage and be destroyed
/// </summary>
public interface IDamagable
{
    int health { get; set; }
    void Damage(int damage);
    void DestroyObject();
}

/// <summary>
/// The object could leave a reward behind (defeat enemy, pick object)
/// </summary>
public interface IDropReward
{
    int rewardProbability { get; set; }
    void DropReward();
}

/// <summary>
/// Check if an object is just pickable
/// </summary>
public interface IPickable
{
    void PickObject();
}
#endregion

#region STRUCTS
/// <summary>
/// Dialogue including the texts the speaker will say
/// </summary>
[System.Serializable]
public class Dialogue
{
    public string speaker;
    [TextArea(3, 10)]
    public string[] textDialogue;
}

/// <summary>
/// Stores the player data, more data could be added here
/// </summary>
[System.Serializable]
public struct PlayerData
{
    public static int money;
    public static int health;

    public static void SetStats(int _money, int _health)
    {
        money = _money;
        health = 100;
        EventManager.TriggerEvent("CurrencyChanged", money);
    }

    public static void ChangeCurrency(int deltaValue)
    {
        money += deltaValue;
        EventManager.TriggerEvent("CurrencyChanged", money);
    }
}
#endregion


