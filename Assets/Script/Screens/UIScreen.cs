using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIScreen : MonoBehaviour
{
    private Image[] allTargetGraphic;
    private bool canAnimate = true;
    private Color [] overrideColor;

    public float animationDuration = 0.3f;

    void OnEnable()
    {
        allTargetGraphic = GetComponentsInChildren<Image>();

        if (allTargetGraphic.Count() < 1)
            canAnimate = false;
        else
            canAnimate = true;
    }

    public abstract void SetupScreen(UIScreen previousScreen);

    public virtual void StartScreen()
    {        
        gameObject.SetActive(true);        

        foreach (var item in allTargetGraphic)
        {
            item.DOFade(1, animationDuration);
        }
    }

    public void CloseScreen()
    {
        CloseScreenWithAwait();
    }

    private async void CloseScreenWithAwait()
    {
        foreach (var item in allTargetGraphic)
        {
            item.DOFade(0, animationDuration);
        }

        await Task.Delay((int)(animationDuration * 1000));

        gameObject.SetActive(false);
    }
}
