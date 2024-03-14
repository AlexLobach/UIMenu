using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private SOItem[] shopItemsSO;
    //[SerializeField] private ShopTemplate[] shopPanels;
    private GameObject itemTemplate;
    private GameObject go;
    [SerializeField] Transform shopScrollView;
    [SerializeField] TMP_Text coinsText;
    private Button buyBtn;

    void Start()
    {
        itemTemplate = shopScrollView.GetChild(0).gameObject;

        int len = shopItemsSO.Length;
        for(int i=0; i<len; i++)
        {
            go = Instantiate(itemTemplate, shopScrollView);
            go.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsSO[i].Icon;
            go.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = shopItemsSO[i].Price.ToString();
            buyBtn = go.transform.GetChild(2).GetComponent<Button>();
            buyBtn.interactable = !shopItemsSO[i].isPurchased;
            buyBtn.AddEventListener(i, OnShopItemClicked);

        }
        Destroy(itemTemplate);
        SetCoinsUI();
    }
    void OnShopItemClicked (int itemIndex)
    {
        if (Coins.Instance.HasEnoughCoins(shopItemsSO[itemIndex].Price))
        {
            Coins.Instance.UseCoins(shopItemsSO[itemIndex].Price);
            //purchase Item
            shopItemsSO[itemIndex].isPurchased = true;
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
