using DG.Tweening;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Image [] objects;
    private string[] names;
    private Dictionary<string, Image> nameGameObject;
    
    
    void Start()
    {
        objects = new Image[10];
        names = new string[10];
        nameGameObject = new Dictionary<string, Image>();

        for (int i = 0; i < objects.Length; i++)
        {

            //objects[i].color = RandomColor();
            names[i] = $"commodity {i + 1}";
            nameGameObject.Add(names[i], objects[i]);


        }
        foreach (var item in nameGameObject)
        {
            //Image obj = Instantiate(item.Value);
            //gameObject.SetActive(true);
            item.Value.DOFade(1, 0.3f);
            string simpleStr = item.Key;
            
            Debug.Log($"{simpleStr}");
            
        }
    }
    
    

    
    private Color RandomColor()
    {
        float [] simplNumArr = {0,0,0,0}; 
        for (int i =0; i<3; i++)
        {
            float num = Random.Range(0, 255);
            simplNumArr[i] = num;

        }
        Color color = new Color(simplNumArr[0],simplNumArr[1], simplNumArr[2], simplNumArr[3]);
        return color;
        
    }

}