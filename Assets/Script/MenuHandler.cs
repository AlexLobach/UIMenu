using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private UIScreen mainMenu;

    void Start()
    {
        mainMenu.StartScreen();
    }
}