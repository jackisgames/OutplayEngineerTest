using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Problem1
{

    internal sealed class Main : MonoBehaviour
    {

        // Use this for initialization
        [SerializeField]int numRacer = 1000;
        [SerializeField]
        SolutionBase originalSolution;
        [SerializeField]
        SolutionBase proposedSolution;

        SolutionBase activeSolution;
        

        List<Racer> racers = new List<Racer>();
        void Start()
        {
            activeSolution = originalSolution;
            generateRacers();
        }
        void generateRacers()
        {
            int numSpawned = numRacer - racers.Count;
            while (numSpawned > 0)
            {
                numSpawned--;
                racers.Add(ScriptableObject.CreateInstance<Racer>());
            }
        }
        // Update is called once per frame
        float delta;
        void Update()
        {
            float beforeExecution = Time.realtimeSinceStartup;
            activeSolution.UpdateRacers(Time.deltaTime, racers);
            float afterExecution = Time.realtimeSinceStartup;
            delta = afterExecution - beforeExecution;
            generateRacers();
        }
        void OnGUI()
        {
            GUI.Label(new Rect(100, 100, 2000, 40), "Execution Speed: " + delta);

            if(GUI.Button(new Rect(100,120, 350, 80),"active solution:\n"+ activeSolution.ToString()))
            {
                if (activeSolution == originalSolution)
                {
                    activeSolution = proposedSolution;
                }
                else
                {
                    activeSolution = originalSolution;
                }
            }
        }
    }
}
