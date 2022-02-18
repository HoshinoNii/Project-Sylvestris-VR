using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory {
    public class Inventory : MonoBehaviour {
        public static Inventory Instance {
            get { return _instance; }
        }

        private static Inventory _instance;
        private List<Item> itemList;
        public GameObject itemPic;
        public Transform InventoryPanel;

        public Sprite[] Thumbnails;
        public Sprite[] SelectedThumbnails;

        public Image CursorImage;
        [HideInInspector] public Item SelectedItem;

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
            CursorImage.sprite = SelectedThumbnails[(int) item.itemType];
            CursorImage.gameObject.SetActive(true);
            item.UI_Item.SetActive(false);
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

        public void AddItem(Item item) {
            GameObject newitem = Instantiate(itemPic, InventoryPanel);
            newitem.GetComponent<UseItem>().item = item;
            newitem.GetComponentsInChildren<Image>()[0].sprite = Thumbnails[(int) item.itemType];
            item.UI_Item = newitem;
            itemList.Add(item);
        }
    }
}