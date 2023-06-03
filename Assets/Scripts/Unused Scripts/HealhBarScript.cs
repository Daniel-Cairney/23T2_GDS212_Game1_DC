using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DanielCairney
{


    public class HealhBarScript : MonoBehaviour
    {
        private Image HeathBar;
        public float CurrentHeath;
        public float MaxHeath = 100f;
        PlayerMovement Player;

        private void Start()
        {
            //find
            HeathBar= GetComponent<Image>();
            Player = FindObjectOfType<PlayerMovement>();
        }

        private void Update()
        {
            //CurrentHeath = Player.Health;
            HeathBar.fillAmount= CurrentHeath / MaxHeath;
        }
    }

}