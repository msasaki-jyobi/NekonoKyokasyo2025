using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-3, 0, 0);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(3, 0, 0);
        }
    }

    public void OnRightMove(int value)
    {
        transform.Translate(value, 0, 0);
    }
    public void OnLeftMove() => transform.Translate(-3, 0, 0);
}
