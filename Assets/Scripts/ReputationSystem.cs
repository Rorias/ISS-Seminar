using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ReputationSystem : MonoBehaviour
{
    public Animator finalAnimation;

    private Image reputationOverlay;
    private Animator anim;
    private TextMeshProUGUI text;

    private void Awake()
    {
        reputationOverlay = GameObject.Find("ReputationOverlay").GetComponent<Image>();
        anim = reputationOverlay.GetComponent<Animator>();
        text = reputationOverlay.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateReputation(float _change)
    {
        reputationOverlay.fillAmount = Mathf.Min(Mathf.Max(reputationOverlay.fillAmount + _change, 0), 1);
        reputationOverlay.color = new Color(0.5f, Mathf.Min(Mathf.Max(reputationOverlay.color.g + _change, 0), 1), 0);

        if (_change >= 0)
        {
            text.color = new Color(0, 1, 0, 1);
            text.text = "+" + (_change * 100).ToString();
        }
        else
        {
            text.color = new Color(1, 0, 0, 1);
            text.text = (_change * 100).ToString();
        }

        anim.Play("Base Layer.MoveTextUp", 0);
    }

    public void SelectEnding()
    {
        if (reputationOverlay.fillAmount >= 0.5)
        {
            ShowGoodEnding();
        }
        else
        {
            ShowBadEnding();
        }
    }

    private void ShowGoodEnding()
    {
        finalAnimation.Play("Ending1", 0);
    }

    private void ShowBadEnding()
    {
        finalAnimation.Play("Ending2", 0);
    }
}
