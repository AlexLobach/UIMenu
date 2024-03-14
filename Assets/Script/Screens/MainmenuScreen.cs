using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuScreen : UIScreen
{
    [SerializeField] private MyButton startGame, options, shop;
    [SerializeField] private UIScreen gameScreen;
    [SerializeField] private UIScreen shopScreen;
    [SerializeField] private UIScreen optionsScreen;
    


    public override void SetupScreen(UIScreen previousScreen)
    {
        Debug.Log("Nothig to setup");        
    }

    public override void StartScreen()
    {
        base.StartScreen();        

        startGame.AddListener(OpenGame);
        shop.AddListener(OpenShop);
        options.AddListener(OpenOptions);
    }

    void OpenGame()
    {
        Debug.Log("Game");
        //gameScreen.SetupScreen(this);
        //CloseScreen();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //gameScreen.StartScreen();
    }

    void OpenShop()
    {
        Debug.Log("Shop");
        shopScreen.SetupScreen(this);
        CloseScreen();
        shopScreen.StartScreen();
    }

    void OpenOptions()
    {
        Debug.Log("Options");
        optionsScreen.SetupScreen(this);
        CloseScreen();
        optionsScreen.StartScreen();

    }
}