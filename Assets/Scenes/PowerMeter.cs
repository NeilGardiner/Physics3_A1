using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerMeter : MonoBehaviour
{
    public float power;
    public Slider slider;
    public bool rising;
    public float speed = 1f;
    public Gradient gradient;
    public Image fill;
    public float maxForce;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rising)
        {
            power += speed * Time.deltaTime;
            
            if(power>1)
            {
                rising = false;
                power -= (power - 1) * 2;
            }
        }
        else
        {
            power -= speed * Time.deltaTime;

            if (power < 0)
            {
                rising = true;
                power += (power * -1) * 2;
            }
        }

        fill.color = gradient.Evaluate(power);

        slider.value = power;
    }

    public void Hit()
    {
        float forceMultiplier = 0;

        if(power >.525 && power < .575)
        {
            //Golden Zone
            forceMultiplier = 1f;
        }
        else
        {
            forceMultiplier = Mathf.Lerp(0.01f, .99f, 1- Mathf.Abs(power - .55f) / .55f);
        }
        Debug.Log("Force: " + forceMultiplier + "Power: " + power);

        rb.AddForce(new Vector3(0, 0, -1) * maxForce * forceMultiplier);
    }
}
