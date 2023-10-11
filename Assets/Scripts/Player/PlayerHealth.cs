using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    private float health;
    private float lerpTimer;
    [Header("Health Bar")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;

    [Header("Damage overlay")]
    public Image overlay; //our DamageOverlay GameObject
    public float duration; //how long the image stays fully opaque
    public float fadeSpeed; //how quickly the image will fade 
    private float durationTimer; //timer to check against the duration

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        Debug.Log(health);
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if (overlay.color.a > 0)
        {
            if(health < 20)
                return;
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                //fade the image
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);

            }
        }
        //   if (Input.GetKeyUp(KeyCode.G))
        //   {
        //       TakeDamage(Random.Range(5, 10));
        //   }
        //   if (Input.GetKeyUp(KeyCode.H))
        //   {
        //       RestoreHealth(Random.Range(5, 10));
        //   }
    }
    public void UpdateHealthUI()
    {
        
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);

        }
        if (fillF < hFraction) 
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer/ chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
        
    }

    public void TakeDamage (float damage) 
    {
        
        health -= damage;
        Debug.Log(health);
        lerpTimer = 0f;
        durationTimer = 0f;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
    }
    public void RestoreHealth(float healAmount) 
    {
        
        health += healAmount;
        Debug.Log(health);
        lerpTimer = 0f;
        
    }
}
