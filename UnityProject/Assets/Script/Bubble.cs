using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] float lifeTime = 3f;
    float timeBeforeDisapearing;
   



    private void Start()
    {
        timeBeforeDisapearing = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeDisapearing -= Time.deltaTime;
        if (timeBeforeDisapearing <= 0 )
        {
            Destroy(this.gameObject);
        }
    }


}
