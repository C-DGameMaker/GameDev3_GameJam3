using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Character Data/Player Data")]
public class PlayerData : BaseCharacterData
{
    [Header("Player Stats")]
    public int currentHealth;
    public int maxHealth;
    public int attack;
    public int defense;

    public void ResetData()
    {
        characterName = "Mario";
        maxHealth = 5;
        currentHealth = maxHealth;
        attack = 1;
        defense = 0;

        
    }
}
