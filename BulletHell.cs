using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : StateMachineBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;

    Animator animator;

    public GameObject bossProjectileTwo;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // InvokeRepeating("Fire", 0f, 2f);
    }

     private void Fire()
     {
       float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirx = animator.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = animator.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirx, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - animator.transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = animator.transform.position;
            bul.transform.rotation = animator.transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BossOneProjectileTwo>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
     }
    

   
     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {
        
     }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
