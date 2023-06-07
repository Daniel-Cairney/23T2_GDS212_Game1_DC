using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DanielCairney
{

    public class HealthController : MonoBehaviour
    {
        public float maxHealth = 100f;
        public float healthDecreaseRate = 10f;
        public float healthIncreaseRate = 10f;
        public Image healthBar;
        public Image visibilityImage;

        private float currentHealth;
        private bool isInsideTriggerZone;

        private void Start()
        {
            currentHealth = maxHealth;
            UpdateHealthBar();
        }

        private void Update()
        {
            if (isInsideTriggerZone)
            {
                // Health decrease over time
                DecreaseHealth(healthDecreaseRate * Time.deltaTime);
                UpdateVisibilityImageAlpha();
            }
            else
            {
                // Health increase over time
                IncreaseHealth(healthIncreaseRate * Time.deltaTime);
                UpdateVisibilityImageAlpha();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // Check if the object entering the trigger zone has the player tag
            if (other.CompareTag("TriggerZone"))
            {
                // Start health decrease
                StartHealthDecrease();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // Check if the object exiting the trigger zone has the player tag
            if (other.CompareTag("TriggerZone"))
            {
                // Stop health decrease and start health increase
                StopHealthDecrease();
                StartHealthIncrease();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            // Check if the object staying in the trigger zone has the player tag
            if (other.CompareTag("TriggerZone"))
            {
                // Set the flag to indicate the player is inside the trigger zone
                isInsideTriggerZone = true;
            }
        }

        private void StartHealthDecrease()
        {
            // Start decreasing health over time
            isInsideTriggerZone = true;
        }

        private void StopHealthDecrease()
        {
            // Stop decreasing health over time
            isInsideTriggerZone = false;
        }

        private void StartHealthIncrease()
        {
            // Start increasing health over time
            isInsideTriggerZone = false;
        }

        private void DecreaseHealth(float amount)
        {
            // Decrease the player's health by the given amount
            currentHealth -= amount;

            // Ensure health doesn't go below 0
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            // Update the health bar UI
            UpdateHealthBar();

            // Check if the player's health reached zero
            if (currentHealth <= 0f)
            {
                // Player dies or takes appropriate action
                Die();
            }
        }

        private void IncreaseHealth(float amount)
        {
            // Increase the player's health by the given amount
            currentHealth += amount;

            // Ensure health doesn't exceed maxHealth
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            // Update the health bar UI
            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            // Update the fill amount of the health bar image
            healthBar.fillAmount = currentHealth / maxHealth;
        }

        private void UpdateVisibilityImageAlpha()
        {
            // Update the alpha value of the visibility image based on health changes
            float alpha = 1f - (currentHealth / maxHealth); // Inverse relation to health
            visibilityImage.color = new Color(visibilityImage.color.r, visibilityImage.color.g, visibilityImage.color.b, alpha);
        }

        private void Die()
        {
            // Handle player death, such as respawning or game over
            Debug.Log("Player died!");
        }
    }





}