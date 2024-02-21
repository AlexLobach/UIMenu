using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SroreScript : MonoBehaviour
{
    private GameObject itemTemplate;
    private GameObject gameObject;
    [SerializeField] Transform shopScrollView;

    void Start()
    {
        itemTemplate = shopScrollView.GetChild(0).gameObject;
        for(int i=0; i<15; i++)
        {
            gameObject = Instantiate(itemTemplate, shopScrollView);
        }
        Destroy(itemTemplate);
    }

}
