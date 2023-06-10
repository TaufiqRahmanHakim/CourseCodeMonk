using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgresUiBar : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image barImage;
    [SerializeField] private Image Bacground;

    private IHasProgressUI hasProgressUI;

    public event EventHandler<IHasProgressUI.OnProgressChangedEventArgs> OnProgressChanged;

    private void Start()
    {
        hasProgressUI = hasProgressGameObject.GetComponent<IHasProgressUI>();
        if(hasProgressUI == null)
        {
            Debug.LogError("Game Object " + hasProgressGameObject + "Does not have a component that implementation IHasProgress!");
        }
        hasProgressUI.OnProgressChanged += hasProgressUI_OnProgressChanged;

        barImage.fillAmount = 0f;
        Hide();
    }

    private void hasProgressUI_OnProgressChanged(object sender, IHasProgressUI.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;
        if(e.progressNormalized == 0f || e.progressNormalized == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        barImage.enabled = true;
        Bacground.enabled = true;
    }
    private void Hide()
    {
        barImage.enabled = false;
        Bacground.enabled = false;
    }
}
