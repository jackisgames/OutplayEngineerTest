using UnityEngine;

namespace Problem4
{
    internal sealed class Dummy:MonoBehaviour
    {
        float timer = 0;
        int travelQueue = 0;
        Vector3 initPos;
        void Start()
        {
            initPos = transform.position;
            transform.localScale = Vector3.one + Random.insideUnitSphere * 3;
        }
        void OnCollisionEnter()
        {
            Debug.Log("foo");
            Main.instance.explode(transform.position);
            Destroy(gameObject);
        }
        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= Main.instance.travelTime)
            {
                initPos = transform.position;
                timer = 0;
                travelQueue++;
                if(travelQueue== Main.instance.targetPoint.Length)
                {
                    OnCollisionEnter();
                }
                
            }
            else
            {
                transform.position = Vector3.Lerp(initPos, Main.instance.targetPoint[travelQueue], timer / Main.instance.travelTime);
            }
        }
    }
}
