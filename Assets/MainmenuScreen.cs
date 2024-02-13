using UnityEngine;

public class MainmenuScreen : UIScreen
{
    [SerializeField] private MyButton startGame, options, shop;

    [SerializeField] private UIScreen gameScreen;

    public override void SetupScreen(UIScreen previousScreen)
    {
        Debug.Log("Nothig to setup");

        // throw new System.NotImplementedException();
    }

    public override void StartScreen()
    {
        base.StartScreen();

        startGame.AddListener(OpenGame);
    }

    void OpenGame()
    {
        Debug.Log("Game");

        gameScreen.SetupScreen(this);

        CloseScreen();

        gameScreen.StartScreen();
    }
}