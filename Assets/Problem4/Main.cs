using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace Problem4
{
    internal sealed class Main : MonoBehaviour
    {
        public static Main instance;
        public Vector3[] targetPoint=new Vector3 [3];
        public float travelTime = 4;
        [SerializeField]Dummy dummy;
        [SerializeField]
        GameObject obstacle;
        [SerializeField]
        AudioSource sfx;
        void Awake()
        {
            instance = this;
        }
        public void AddPathDummy()
        {
            Dummy obj= Instantiate(dummy);
            
        }
#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            Handles.color = Color.red;
            for(int i = 0; i < targetPoint.Length; i++)
            {
                Handles.DrawLine(targetPoint[i], targetPoint[(i + 1)%targetPoint.Length]);
            }
        }
#endif
        // Use this for initialization
        void Start()
        {
            AddPathDummy();
            for(int i = 0; i < 100; i++)
            {
                Instantiate(obstacle, Random.insideUnitSphere * 40, Quaternion.identity);
            }
        }
        [SerializeField]
        ParticleSystem particle;
        public void explode(Vector3 pos)
        {
            particle.transform.position = pos;
            
            particle.Emit(30);
            
            sfx.Play();
        }
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
