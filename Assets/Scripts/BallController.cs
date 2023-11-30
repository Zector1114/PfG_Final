using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    bool canMove;
    bool destroyCheck;
    int destroyCount = 0;
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

        if (destroyCheck) destroyCount++;
        else destroyCount = 0;

        if (destroyCount == 10) LetsDestroy();
    }

    public void SwapAxis()
    {
        if (!canMove) canMove = true;

        if (moveDirection == Vector3.forward) moveDirection = Vector3.right;
        else moveDirection = Vector3.forward;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            destroyCheck = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            destroyCheck = false;
        }
    }

    void LetsDestroy()
    {
        moveDirection = Vector3.down;
        Destroy(gameObject, t: 5);
    }
}
