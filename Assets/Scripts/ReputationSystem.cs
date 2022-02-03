using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ReputationSystem : MonoBehaviour
{
    private Image reputationOverlay;

    private void Awake()
    {
        reputationOverlay = GameObject.Find("ReputationOverlay").GetComponent<Image>();
    }

    public void UpdateReputation(float _change)
    {
        reputationOverlay.fillAmount = Mathf.Min(Mathf.Max(reputationOverlay.fillAmount + _change, 0), 1);
        reputationOverlay.color = new Color(0.5f, Mathf.Min(Mathf.Max(reputationOverlay.color.g + _change, 0), 1), 0);
    }
}
