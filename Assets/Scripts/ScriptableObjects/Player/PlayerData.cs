using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Character Data/Player Data")]
public class PlayerData : BaseCharacterData
{
    [Header("Player Stats")]
    public int currentHealth;
    public int maxHealth;
    public int attack;
    public int speed;
    public int defense;
    public int luck;
}
