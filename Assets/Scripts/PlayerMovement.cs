using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    public bool pausedMovement;
    public bool changedPos;
    public bool isReverse;
    [HideInInspector]
    public int currnetPosNumer = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = target[currnetPosNumer].position;
        currnetPosNumer += 1;
        pausedMovement = false;
        changedPos = false;
        isReverse = false;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (!changedPos)
        {
            if (Mathf.Abs(transform.position.x - target[currnetPosNumer].position.x) <= 0.01)
            {
                Debug.Log("reached");
                pausedMovement = true;
                changedPos = true;
                if (currnetPosNumer == 1)
                {
                    Invoke("pausedCubeAtPostion", 3f);
                }
                else
                {
                    pausedCubeAtPostion();
                }
            }
        }

        if (!pausedMovement)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[currnetPosNumer].position, step);
        }
    }

    public void pausedCubeAtPostion()
    {
        //for reverse path
        if (isReverse)
        {
            currnetPosNumer -= 1;
        }
        else
        {
            currnetPosNumer += 1;
        }

        //Change point 
        if (currnetPosNumer < 0)
        {
            currnetPosNumer = 1;
            isReverse = false;
        }
        if (currnetPosNumer > 2)
        {
            currnetPosNumer = 1;
            isReverse = true;
        }

        pausedMovement = false;
        changedPos = false;
    }
}
