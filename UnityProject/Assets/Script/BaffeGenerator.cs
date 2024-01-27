using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BaffeGenerator : ListenerGameEvent
{
    Animator myAnimator;

    void Awake()
    {
        base.Start();
        myAnimator = GetComponent<Animator>();
    }


    public override void notifygameEvent(GameManager.GameEvent elEvento)
    {
        if(elEvento == GameManager.GameEvent.ENDROUND)
        {
            myAnimator.SetTrigger("baffe");
        }
    }
}
