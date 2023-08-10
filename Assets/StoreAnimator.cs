using UnityEngine;

public class StoreAnimator : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Upgrade()
    {
        animator.SetTrigger(TreasureCurseConst.AnimatorUpgradeText);
    }

    public void EndUpgrade()
    {
        animator.SetTrigger(TreasureCurseConst.AnimatorEndUpgradeText);
    }
}
