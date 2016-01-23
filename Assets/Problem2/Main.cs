using UnityEngine;
namespace Problem2
{
    internal sealed class Main : MonoBehaviour
    {
        [SerializeField]
        float checkHeight;
        [SerializeField]
        float width;
        [SerializeField]
        float gravity;
        [SerializeField]
        Vector2 origin;
        [SerializeField]
        Vector2 velocity;
        [SerializeField]
        float groundHeight;
        [SerializeField]
        Texture ballOrigin;
        [SerializeField]
        Texture ballAlpha;
        [SerializeField]
        Texture ballRed;

        const float ballRad = 10;
        void OnGUI()
        {
            origin.x = Mathf.Clamp(origin.x, 0, width);
            origin.y = Mathf.Max(0, origin.y);
            //draw ground
            GUI.DrawTexture(new Rect((Screen.width-width) / 2, Screen.height-groundHeight, width, 1), Texture2D.whiteTexture);
            //draw ground
            GUI.Label(new Rect((Screen.width - width) / 2, Screen.height-groundHeight - checkHeight-18, width, 30),"Check Height");
            GUI.DrawTexture(new Rect((Screen.width - width) / 2, Screen.height-groundHeight - checkHeight, width, 1), Texture2D.whiteTexture);
            //draw wall
            GUI.DrawTexture(new Rect((Screen.width - width) / 2, 0, 1, Screen.height-groundHeight), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect((Screen.width + width) / 2, 0, 1, Screen.height - groundHeight), Texture2D.whiteTexture);
            //draw Origin Ball
            drawBall(origin, ballOrigin);

            float resultX=0;
            //magic
            TryCalculateXPositionAtHeight(checkHeight, origin, velocity, gravity, width,ref resultX);
            
        }
        void drawBall(Vector2 pos,Texture tex)
        {
            GUI.DrawTexture(new Rect((Screen.width - width) / 2 + pos.x - ballRad / 2, Screen.height - groundHeight - pos.y - ballRad / 2, ballRad, ballRad), tex);
        }
        float getXValue(Vector2 posA, Vector2 posB, float x)
        {
            float min = Mathf.Min(posA.x, posB.x);
            float max = Mathf.Max(posA.x, posB.x);
            return (x - min) / (max - min);
        }
       
        bool TryCalculateXPositionAtHeight(float h, Vector2 p, Vector2 v, float G, float w,ref float xPosition)
        {
            
            Vector2 _p = p;
            Vector2 _v = v;
            float _g = G;
            Vector2 prevP = _p;
            int numCalc = 100;
            while (numCalc>0)
            {
                numCalc--;
                
                //apply velocity&grav
                _p += _v + Vector2.down * _g;
                //wallCollision;
                if (_p.x > w)
                {

                    _p = Vector2.Lerp(prevP, _p, getXValue(_p, prevP, w));
                    
                    _v.x = -_v.x;
                }
                else if (_p.x < 0)
                {
                    _p = Vector2.Lerp(_p, prevP, getXValue(_p, prevP, 0));
                    _v.x = -_v.x;
                }

                //check if cross the line
                Vector2 lowerPos;
                Vector2 higherPos;
                if (_p.y >= prevP.y)
                {
                    higherPos = _p;
                    lowerPos = prevP;
                }
                else
                {
                    higherPos = prevP;
                    lowerPos = _p;
                }

                prevP = _p;
                if (higherPos.y >= h && lowerPos.y <= h)
                {
                    //hit border, draw red ball & end calculation
                    float value = (h - lowerPos.y) / (higherPos.y - lowerPos.y);
                    Vector2 resultPos = Vector2.Lerp(lowerPos, higherPos, value);
                    xPosition = resultPos.x;
                    drawBall(resultPos, ballRed);
                    return true;
                }
                

                //check if hit ground then end calculation
                if (_p.y <= 0)
                {
                    _p.y = 0;
                    drawBall(_p, ballRed);
                    return false;
                }
                else {
                    //continue and draw alpha ball
                    _g += G;
                    drawBall(_p, ballAlpha);
                }
            }
            return false;
        }

    }
}
