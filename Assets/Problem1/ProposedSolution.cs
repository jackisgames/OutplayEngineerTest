

using System.Collections.Generic;

namespace Problem1
{
    internal sealed class ProposedSolution : SolutionBase
    {
        public override void UpdateRacers(float deltaTimeS, List<Racer> racers)
        {
            int numRacer = racers.Count;
            deltaTimeS *= 1000.0f;
            for (int racerIndex1 = 0; racerIndex1 < numRacer; racerIndex1++)
            {
                Racer racerA = racers[racerIndex1];
                // Updates the racers that are alive
                if (racerA.IsAlive())
                {
                    //Racer update takes milliseconds
                    racerA.update(deltaTimeS);
                    for (int racerIndex2 = 0; racerIndex2 < numRacer; racerIndex2++)
                    {
                        
                        if (racerIndex1 != racerIndex2)
                        {
                            Racer racerB = racers[racerIndex2];
                            // Collides
                            if (racerA.IsCollidable() && racerB.IsCollidable() && racerA.CollidesWith(racerB))
                            {
                                OnRacerExplodes(racerA);
                                // Get rid of all the exploded racers
                                racers.RemoveAt(racerIndex1);
                                racerIndex1--;
                                numRacer--;
                                break;
                                //
                            }
                        }
                        
                    }
                }
                else
                {
                    racerA.Destroy();
                    racers.RemoveAt(racerIndex1);
                    racerIndex1--;
                    numRacer--;
                }
            }
        }
    }
}
