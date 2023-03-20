using Unity.VisualScripting;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    private Vector3 poin0;
    public Vector3 poin1;
    private Vector3 poin2;
    public bool valueSpeed;
    public float speed;
    public float range;
    

    private void Awake()
    {
        
        poin1 = this.transform.position;          
        poin0.y = poin1.y + range;        
        poin2.y = poin1.y - range;
        
    }

    /*public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(poin0, 0.1f);
        Gizmos.DrawSphere(poin2, 0.1f);
    }*/

    private void FixedUpdate()
    {        
        MovePlatform();
    }

    private void MovePlatform()
    {
        
        if (valueSpeed)
        {
            poin1.y += speed * Time.deltaTime;
            if (poin1.y > poin0.y)
            {
                speed = -Mathf.Abs(speed);
            }
            else if (poin1.y < poin2.y)
            {
                speed = Mathf.Abs(speed);
            }
        }
        else
        {
            poin1.y += -speed * Time.deltaTime;
            if (poin1.y > poin0.y)
            {
                speed = Mathf.Abs(speed);
            }
            else if (poin1.y < poin2.y)
            {
                speed = -Mathf.Abs(speed);
            }
        }
        transform.position = poin1;
    }


}
