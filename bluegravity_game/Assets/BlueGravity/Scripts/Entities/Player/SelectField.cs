using UnityEngine;
using BlueGravity.Inventory;

namespace BlueGravity.Entities.Player
{
    public class SelectField : MonoBehaviour
    {
        [Header("Colors")]
        [SerializeField] private Color normalColor;
        [SerializeField] private Color pickableColor;
        [SerializeField] private Color unpickableColor;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PickableItem"))
            {
                ItemPick itemPick = collision.GetComponent<ItemPick>(); 

                if (itemPick)
                {
                    if (itemPick.CheckPickUp()) spriteRenderer.color = pickableColor;
                    else spriteRenderer.color = unpickableColor;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("PickableItem")) spriteRenderer.color = normalColor;
        }
    }
}