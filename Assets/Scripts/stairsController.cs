using System.Collections;
using System.Collections.Generic;
using UnityEditor.Toolbars;
using UnityEngine;

public class stairsController : MonoBehaviour
{
    public int stairRotationalOffset;
    public int stairDownRotationalOffset;
    public int surfaceArcDown;
    public int surfaceArc;

    private bool exitPlatform;

    private PlatformEffector2D stairPlatformEffector;
    // Start is called before the first frame update
    void Start()
    {
        stairPlatformEffector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") < 0 && !exitPlatform)
        {
            stairPlatformEffector.surfaceArc = surfaceArcDown;
            exitPlatform = true;
        }
    }
    //TO DO:Improve movement between stairs 
    private void OnCollisionExit2D(Collision2D collision)
    {
        stairPlatformEffector.surfaceArc = surfaceArc;

        exitPlatform = false;
    }
}
