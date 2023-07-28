using BlueGravity.Inventory;
using BlueGravity.Inventory.Seller;
using BlueGravity.Toolbox;
using UnityEngine;
using UnityEngine.Events;

namespace BlueGravity.Entities.Seller
{
    public class SellerInventory : MonoBehaviourSingleton<SellerInventory>
    {
        [Header("Coins")]
        [SerializeField] private int coins;

        [Header("UI")]
        [SerializeField] private GameObject UI;

        [Header("Inventory")]
        [SerializeField] private GameObject sellerInventory;

        private bool collidingPlayer = false;

        public bool openInventory { get; private set; }

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
            SellerInventoryManager.Instance.UpdateCoinsUI(coins);
            openInventory = true;
        }

        private void CloseInventory()
        {
            sellerInventory.SetActive(false);
            openInventory = false;
        }

        public int GetCoins()
        {
            return coins;
        }

        public void Sell(int coins)
        {
            this.coins += coins;
            SellerInventoryManager.Instance.UpdateCoinsUI(this.coins);
        }

        public void Buy(int coins)
        {

            this.coins -= coins;
            SellerInventoryManager.Instance.UpdateCoinsUI(this.coins);
        }
    }
}