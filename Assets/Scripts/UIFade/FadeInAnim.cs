using UnityEngine;

public class FadeInAnim : StateMachineBehaviour
{
	ScreenFader sf;

	private void Awake()
	{
		sf = GameObject.Find("Fader").GetComponent<ScreenFader>();
	}

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		sf.doneFadingOut = false;
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool("StartFadingIn", false);
	}
}
