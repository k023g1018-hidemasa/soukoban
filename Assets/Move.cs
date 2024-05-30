using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float timeTaken = 0.2f;

    float timeErapsed;

    Vector3 destination;

    Vector3 origin;





    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        origin = destination;

    }

    // Update is called oncesaq@2ie per frame
    void Update()
    {


        if (transform.position == destination)
        {
            return;
        }



        timeErapsed += Time.deltaTime;

        float timeRate = timeErapsed / timeTaken;

        if (timeRate > 1) { timeRate = 1; }

        float easing = timeRate;

        Vector3 currentPosition = Vector3.Lerp(origin, destination, easing);

        transform.position = currentPosition;


    }

    public void MoveTo(Vector3 destination)
    {
        timeErapsed = 0;
        origin = this.destination;
        // 移動中だった場合はキャンセルして目的にワープする
        transform.position = origin;
        this.destination = destination;
    }






}
