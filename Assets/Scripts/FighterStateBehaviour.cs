using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStateBehaviour : StateMachineBehaviour{

    public FighterStates behaviourState;

    public float horizontalForce;
    public float verticalForce;

    protected Fighter fighter;

    override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex){

        if (fighter == null){
            fighter = animator.gameObject.GetComponent<Fighter>();
        }

        fighter.currentState = behaviourState;

        fighter.body.AddRelativeForce (new Vector3 (0, verticalForce, 0));
    }

    override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex){

        fighter.body.AddRelativeForce (new Vector3 (0, 0, horizontalForce));

    }

}
