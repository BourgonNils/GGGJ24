using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class ListenerGameEvent :MonoBehaviour
{

    [SerializeField] GameManager.GameEvent eventToReactTo;
    [SerializeField] UnityEvent reaction;
    public void notifygameEvent(GameManager.GameEvent elEvento)
    {
        if(elEvento ==eventToReactTo)
            reaction.Invoke();
    }

    private void Start()
    {
        GameManager.instance.addListener(this);
    }
    private void OnDestroy()
    {
        GameManager.instance.removeListener(this);
    }

}
