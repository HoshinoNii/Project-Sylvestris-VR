using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory {
    public class Inventory : MonoBehaviour {
        public static Inventory Instance {
            get { return _instance; }
        }

        private static Inventory _instance;

        [SerializeField] private int inventoryLimit;
        [SerializeField] private List<Item> itemList;
        public GameObject itemPic;
        public Transform InventoryPanel;

        public Sprite[] CoffeeThumbnails;
        public Sprite[] SelectedCoffeeThumbnails;

        public Sprite[] IngredentThumbmails;
        public Sprite[] SelectedIngredientThumbnails;

        public Image CursorImage;
        public Item SelectedItem;

        private void Awake() {
            if (_instance != null && _instance != this) {
                Destroy(this.gameObject);
            } else {
                _instance = this;
            }
        }

        private void Start() {
            itemList = new List<Item>();
            //Debug.Log("Inventory");
        }


        private void Update() {
            //Cancel the selection
            if (Input.GetMouseButton(1)) {
                CursorImage.gameObject.SetActive(false);
                if (SelectedItem) SelectedItem.UI_Item.SetActive(true);
                SelectedItem = null;
            }
        }

        public void UseItem(Item item) {
            if (SelectedItem) SelectedItem.UI_Item.SetActive(true);

            SelectedItem = item;
            CursorImage.sprite = SelectedCoffeeThumbnails[(int) item.itemType];
            CursorImage.gameObject.SetActive(true);
            item.UI_Item.SetActive(false);
        }

        public void UseItem(Item item, IngredientType ingredientType) {
            UseItem(item);
            CursorImage.sprite = SelectedIngredientThumbnails[(int) ingredientType];
        }

        public void UsedItem() {
            CursorImage.gameObject.SetActive(false);

            SelectedItem.numberOfUse--;
            if (SelectedItem.numberOfUse <= 0)
                Destroy(SelectedItem.UI_Item);
            else
                SelectedItem.UI_Item.SetActive(true);

            SelectedItem = null;
        }

        public UseItem AddItem(Item item) {
            
            if (itemList.Count > inventoryLimit) return null;
            GameObject newitem = Instantiate(itemPic, InventoryPanel);
            UseItem useItem = newitem.GetComponent<UseItem>();
            useItem.item = item;;
            item.UI_Item = newitem;
            itemList.Add(item);
            return useItem;
        }

        public void AddItem(Item item, CoffeeItem coffeeItem) {
            UseItem useItem = AddItem(item);

            if (useItem == null) return;
            
            useItem.isIngredient = true;
            useItem.coffeeType = coffeeItem.coffeeType;
            useItem.GetComponentsInChildren<Image>()[0].sprite = CoffeeThumbnails[(int) coffeeItem.coffeeType];
        }
        
        public void AddItem(Item item, Ingredient ingredient) {
            UseItem useItem = AddItem(item);

            if (useItem == null) return;
            
            useItem.isIngredient = true;
            useItem.ingredientType = ingredient.ingredientType;
            useItem.GetComponentsInChildren<Image>()[0].sprite = IngredentThumbmails[(int) ingredient.ingredientType];
        }
    }
}