using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public bool canAttack;
    public float cooldownTime;
    public void Attack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (canAttack == false)
            {
                Debug.Log("Cant attack");
                return;
            }

            Debug.Log("Attacked");
            canAttack = false;

            StartCoroutine(Cooldown(cooldownTime));
        }
    }

    IEnumerator Cooldown(float timeToCooldown)
    {
        yield return new WaitForSeconds(timeToCooldown);
        canAttack = true;
        Debug.Log("Can attack again");
        yield break;
    }
}
