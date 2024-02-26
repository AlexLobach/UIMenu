using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SroreScript : MonoBehaviour
{
    [System.Serializable] class ShopItem
    {
        public Sprite image;
        public int price;
        public bool isPurchased = false;
    }
    [SerializeField] List<ShopItem> shopItemsList;
    private GameObject itemTemplate;
    private GameObject go;
    [SerializeField] Transform shopScrollView;
    [SerializeField] TextMeshProUGUI coinsText;
    private Button buyBtn;

    void Start()
    {
        itemTemplate = shopScrollView.GetChild(0).gameObject;

        int len = shopItemsList.Count;
        for(int i=0; i<len; i++)
        {
            go = Instantiate(itemTemplate, shopScrollView);
            go.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsList[i].image;
            go.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = shopItemsList[i].price.ToString();
            buyBtn = go.transform.GetChild(2).GetComponent<Button>();
            buyBtn.interactable = !shopItemsList[i].isPurchased;
            buyBtn.AddEventListener(i, OnShopItemClicked);

        }
        Destroy(itemTemplate);
        SetCoinsUI();
    }
    void OnShopItemClicked (int itemIndex)
    {
        if (Coins.Instance.HasEnoughCoins(shopItemsList[itemIndex].price))
        {
            Coins.Instance.UseCoins(shopItemsList[itemIndex].price);
            //purchase Item
            shopItemsList[itemIndex].isPurchased = true;
            buyBtn = shopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();        
            // disable the button
            buyBtn.interactable = false;
            SetCoinsUI();

        }
        else
        {
            Debug.Log("you don't have enough coins");
        }
        
    }
    void SetCoinsUI()
    {
        coinsText.text = Coins.Instance.coins.ToString();
    }

}
