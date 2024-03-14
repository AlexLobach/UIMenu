using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public static Coins Instance;    
    public int coins;
    

    void Awake()
    {
        if (Instance == null)
        {            
            Instance = this;            
            DontDestroyOnLoad(gameObject);                       
        }
        else
        {            
            Destroy(gameObject);            
        }    

    }
    public void UseCoins(int amount)
    {
        coins -= amount;
    }
    public bool HasEnoughCoins( int amount)
    {
        return (coins >= amount);
    }

    void Start()
    {
        coins = PlayerPrefs.GetInt("Gold", 0);
    }

    void Update()
    {
        PlayerPrefs.SetInt("Gold", coins);
    }

}
