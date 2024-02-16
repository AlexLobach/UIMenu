using UnityEngine;

public class OptionsScreen : UIScreen
{
    [SerializeField] private MyButton back;

    private UIScreen menuScreen;

    public override void SetupScreen(UIScreen previousScreen)
    {
        if (menuScreen == null)
            menuScreen = previousScreen;

        back.AddListener(BackToMenu);
    }

    void BackToMenu()
    {
        CloseScreen();
        menuScreen.StartScreen();
    }
}