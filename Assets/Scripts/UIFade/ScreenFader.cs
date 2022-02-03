using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    private Animator anim;
    private Image image;

    [HideInInspector] public bool doneFadingOut = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        image = GetComponent<Image>();
    }

    public void FadeOut(Color fadeColor)
    {
        image.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b);
        anim.SetBool("StartFadingOut", true);
    }

    public void FadeIn()
    {
        anim.SetBool("StartFadingIn", true);
    }
}
