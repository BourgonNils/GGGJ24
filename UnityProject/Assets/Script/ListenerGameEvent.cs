using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class ListenerGameEvent :MonoBehaviour
{

    [SerializeField] GameManager.GameEvent eventToReactTo;
    [SerializeField] UnityEvent reaction;

    [SerializeField] float delay = 0f;
    public virtual void notifygameEvent(GameManager.GameEvent elEvento)
    {
        if(delay !=0f)
        {
            StartCoroutine(waitThenProc(elEvento));
            return;
        }
        if(elEvento ==eventToReactTo)
            reaction.Invoke();
    }

    IEnumerator waitThenProc(GameManager.GameEvent elEvento)
    {
        yield return new WaitForSeconds(delay);
        if (elEvento == eventToReactTo)
            reaction.Invoke();
    }

    protected void Start()
    {
        GameManager.instance.addListener(this);
    }
    private void OnDestroy()
    {
        GameManager.instance.removeListener(this);
    }

}
