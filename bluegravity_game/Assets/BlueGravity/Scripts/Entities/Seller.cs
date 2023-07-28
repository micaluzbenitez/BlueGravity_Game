using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravity.Entities
{
    public class Seller : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject UI;

        private bool collidingPlayer = false;

        private void Update()
        {
            if (collidingPlayer && Input.GetKeyDown(KeyCode.E)) OpenInventory();
            UpdateUI();
        }

        #region Player_Detection
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidingPlayer = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidingPlayer = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidingPlayer = false;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidingPlayer = false;
        }
        #endregion

        private void UpdateUI()
        {
            if (collidingPlayer) UI.SetActive(true);
            else UI.SetActive(false);
        }

        private void OpenInventory()
        {
            Debug.Log("open inventory");
        }
    }
}