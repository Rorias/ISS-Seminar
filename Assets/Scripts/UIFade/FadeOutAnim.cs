using UnityEngine;

public class FadeOutAnim : StateMachineBehaviour
{
	ScreenFader sf;

	private void Awake()
	{
		sf = GameObject.Find("Fader").GetComponent<ScreenFader>();
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool("StartFadingOut", false);
		sf.doneFadingOut = true;
	}
}
