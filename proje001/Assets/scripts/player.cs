using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    [SerializeField] private TMP_Text ballCountText = null;
    [SerializeField] private List<GameObject> ball = new List<GameObject>();
    private int ballCount = 0;
    private Touch touch;
    [Range(0, 200)]
    [SerializeField] private float speedModifier;
    [SerializeField] private Rigidbody rb;
    public int forwartspeed;
    private bool speedcontrol = false;
    private bool firsttouccontrol = false;

    void Update()
    {
        UpdateBallCountText();
        ballCount = ball.Count;

        if (variable.firsttouch == 1 && speedcontrol == false)
        {
            transform.Translate(Vector3.forward * forwartspeed * Time.deltaTime);
        }


        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {

                if (firsttouccontrol == false)
                {

                    variable.firsttouch = 1;

                    firsttouccontrol = true;
                }


            }


            else if (touch.phase == TouchPhase.Moved)
            {





                rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                           transform.position.y,
                                           touch.deltaPosition.y * speedModifier * Time.deltaTime);

                if (firsttouccontrol == false)
                {

                    variable.firsttouch = 1;

                    firsttouccontrol = true;
                }

            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }

            else if (touch.phase == TouchPhase.Stationary)
            {

                rb.velocity = Vector3.zero;
            }
        }

    }
    private void UpdateBallCountText()
    {
        ballCountText.text = ball.Count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(0f, 0f, ball[ball.Count - 1].transform.localPosition.z - 1f);
            ball.Add(other.gameObject);
        }
    }
}
