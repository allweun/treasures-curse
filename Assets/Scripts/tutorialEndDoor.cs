using UnityEngine;

public class tutorialEndDoor : MonoBehaviour
{
    public Animator animator;
    public Transform playercol;
    public Controller controller;
    public CameraEX cameraEX;
    public TutorialManager tutorial;

    void Update()
    {
        if (!tutorial.tutorialEnd)
            if (Mathf.Abs(playercol.position.x - transform.position.x) < 5)
            {
                animator.SetTrigger(TreasureCurseConst.CloseKey);
                controller.Stop();
                cameraEX.XMaxVal = 127;
                cameraEX.XMaxEnabled = true;
                tutorial.tutorialEnd = true;
            }
    }

    public void LastAnim()
    {
        animator.SetTrigger(TreasureCurseConst.ClosedKey);
    }
}
