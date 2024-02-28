using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Vector3 MouseIn;
    Vector2 MouseCoords;
    Vector3 PaddlePos;
    Vector3 PaddleMovement;
    Vector3 PaddleTarget;
    public Rigidbody2D PaddleBody;
    float Constraint;
    float PaddleSpeed;
    float CurrentPos;
    // Start is called before the first frame update
    void Start()
    {
        Constraint = 5.25f;
        PaddlePos = gameObject.transform.position;
        PaddleTarget = new Vector3(0, PaddlePos.y, 0);
        MouseCoords = new Vector2(0, 0);
        PaddleBody = GetComponent<Rigidbody2D>();
        PaddleSpeed = 0.3f;
        CurrentPos = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        MouseIn = Input.mousePosition;
        MouseCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (MouseCoords.x < -Constraint)
        {
            PaddleTarget.x = -Constraint;
        } 
        else if (MouseCoords.x > Constraint)
        {
            PaddleTarget.x = Constraint;
        }
        else
        {
            PaddleTarget.x = MouseCoords.x;
        }
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, PaddleTarget, PaddleSpeed);
    }
}
