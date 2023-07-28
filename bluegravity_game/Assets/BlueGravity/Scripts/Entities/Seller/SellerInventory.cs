using UnityEngine;
using UnityEngine.Events;

namespace BlueGravity.Entities.Seller
{
    public class SellerInventory : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject UI;

        [Header("Inventory")]
        [SerializeField] private GameObject sellerInventory;

        [Header("Events")]
        [SerializeField] private UnityEvent OnOpenInventory;
        [SerializeField] private UnityEvent OnCloseInventory;

        private bool collidingPlayer = false;

        private void Update()
        {
            if (collidingPlayer && Input.GetKeyDown(KeyCode.E))
            {
                if (!sellerInventory.activeSelf) OpenInventory();
                else CloseInventory();
            }

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
            sellerInventory.SetActive(true);
            OnOpenInventory?.Invoke();
        }

        private void CloseInventory()
        {
            sellerInventory.SetActive(false);
            OnCloseInventory?.Invoke();
        }
    }
}