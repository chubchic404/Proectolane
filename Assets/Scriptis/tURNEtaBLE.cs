using Unity.VisualScripting;
using UnityEngine;

public class tURNEtaBLE : MonoBehaviour
{

    [SerializeField] private float degrees = 45f;
    [SerializeField] private bool isActive = true;
    [SerializeField] private bool isActive2 = true;
    [SerializeField] private bool isActive3 = true;
    private void Start()
    {
         transform.rotation = Quaternion.identity;   
    }


    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        float angle = degrees * Time.deltaTime;

        transform.Rotate(0f, angle, 0f, Space.Self);
        if (isActive2) { transform.Rotate(angle, 0f, 0f, Space.Self); }

        if (isActive3) { transform.Rotate(0f, 0f, angle, Space.Self); }
    }
}
