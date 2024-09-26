using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Powerups/armor")]
public class Armour : PowerUps
{
    public GameObject birb;
    public audiomanager audiomanager;
    public Image shieldtimer;
    private Coroutine expireCoroutine;

    public override void Apply(GameObject target)
    {
        audiomanager = GameObject.FindGameObjectWithTag("audio")?.GetComponent<audiomanager>();
        if (audiomanager == null) return;

        birb birbComponent = target.GetComponent<birb>();
        if (birbComponent == null) return;

        // Find the shield timer only if it hasn't been found already
        if (shieldtimer == null)
        {
            shieldtimer = GameObject.FindGameObjectWithTag("timer")?.GetComponent<Image>();
            if (shieldtimer == null) return;
        }

        // Stop any existing coroutine to reset the timer
        if (expireCoroutine != null)
        {
            birbComponent.StopCoroutine(expireCoroutine);
        }

        // Activate the shield
        birbComponent.invincible = true;
        shieldtimer.gameObject.SetActive(true); // Show the shield timer
        shieldtimer.fillAmount = 1f; // Reset the timer UI
        birbComponent.animator.SetBool("isArmored", true);

        // Start the expiration coroutine
        expireCoroutine = birbComponent.StartCoroutine(Expire(target));
        audiomanager.playSFX(audiomanager.armor);
    }

    private IEnumerator Expire(GameObject target)
    {
        birb birbComponent = target.GetComponent<birb>();
        float duration = 5f;
        float elapsed = 0f;

        while (elapsed <= duration)
        {
            elapsed += Time.deltaTime;
            shieldtimer.fillAmount = 1f - (elapsed / duration); // Update shield timer UI
            yield return null;
        }

        // Disable invincibility and hide the timer when the shield expires
        birbComponent.invincible = false;
        birbComponent.animator.SetBool("isArmored", false);
        shieldtimer.gameObject.SetActive(false); // Hide the shield timer
    }
}
