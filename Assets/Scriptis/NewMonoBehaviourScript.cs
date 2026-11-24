using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float DPS = 45f;
    [SerializeField] private float Razgon = 1f;
    [SerializeField] private bool isRunning = true;
    [SerializeField] private bool isRunning2 = true;
    [SerializeField] private bool isRunning3 = true;
    [SerializeField] private bool isRazgon = true;
    [SerializeField] private bool isInverv = false;

    private void Update()
    {
        float angle = DPS * Time.deltaTime;

        if (isRunning)
        {
            transform.Rotate(angle, 0f, 0f, Space.Self);
        }

        if (isRunning2)
        {
            transform.Rotate(0f, angle, 0f, Space.Self);
        }

        if (isRunning3)
        {
            transform.Rotate(0f, 0f, angle, Space.Self);
        }

        if (isRazgon) 
        {
            if (!isInverv)
            {
                DPS += Razgon;
            }
            else
            {
                DPS -= Razgon;
            }
        }



        if (!isRunning || !isRunning2 || !isRunning3 || !isRazgon )
        {
            return;
        }

        
        
    }
}
