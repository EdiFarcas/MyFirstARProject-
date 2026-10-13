using UnityEngine;
using Vuforia;

public class CharacterProximityController : MonoBehaviour
{
    public ImageTargetBehaviour target1;
    public ImageTargetBehaviour target2;

    public Animator animator1;
    public Animator animator2;

    public float attackDistance = 1.5 f;

    void Update()
    {
        if (target1 == null || target2 == null ||
            animator1 == null || animator2 == null)
        {
            Debug.LogError("LIPSESC REFERINTE!");
            return;
        }

        Status status1 = target1.TargetStatus.Status;
        Status status2 = target2.TargetStatus.Status;

        bool visible1 =
            status1 == Status.TRACKED ||
            status1 == Status.EXTENDED_TRACKED ||
            status1 == Status.LIMITED;

        bool visible2 =
            status2 == Status.TRACKED ||
            status2 == Status.EXTENDED_TRACKED ||
            status2 == Status.LIMITED;

        bool shouldAttack = false;
        float distance = -1f;

        if (visible1 && visible2)
        {
            distance = Vector3.Distance(
                target1.transform.position,
                target2.transform.position
            );

            shouldAttack = distance <= attackDistance;
        }

        animator1.SetBool("IsAttacking", shouldAttack);
        animator2.SetBool("IsAttacking", shouldAttack);

        Debug.Log(
            "T1=" + status1 +
            " | T2=" + status2 +
            " | DIST=" + distance +
            " | ATTACK=" + shouldAttack
        );
    }
}