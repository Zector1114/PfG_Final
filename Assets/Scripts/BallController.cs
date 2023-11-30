using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    bool canMove;
    Vector3 moveDirection = Vector3.forward;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        InputManager.EnableInGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            transform.position += speed * Time.deltaTime * moveDirection;
        }
    }

    public void SwapAxis()
    {
        if (!canMove) canMove = true;

        if (moveDirection == Vector3.forward) moveDirection = Vector3.right;
        else moveDirection = Vector3.forward;
    }
}
