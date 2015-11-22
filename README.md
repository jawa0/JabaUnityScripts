# JabaUnityScripts
Helper scripts for Unity development

DebugDrawCollisions
-

This script will draw all contact normals at all contact points for the given object. You can use this to debug collision problems. The colour and scale of the lines used to draw the normals is customizable. Make sure to enable Gizmos if you want to see the output in the Game window, not just the Scene window.

DebugDrawSpringJoints
-

This script is useful for debugging Unity's SpringJoints. Unity will draw the spring's anchors, but not a line connecting the ends. When you put this script on a GameObject, it will draw a coloured line for each SpringJoint also attached to that object. The colour of the line shows whether that spring is stretched, compressed, or neutral.

You can set the stretched, compressed, or neutral colours to whatever you want.
NOTE: you need to enable show gizmos (button in top-right of Game view) if you want to see the springs in the Game window, not just in the Scene window.

BooleanSignal
-

There are often times where you'll want to be able to tell whether some true/false condition changed from false to true or from true to false. Typically, you end up adding pairs of variables for the present and previous values of the condition. BooleanSignal just wraps this so you can add one field of type BooleanSignal, instead of two separate bools.

For example:
    
    private BooleanSignal isAirborne;
    
    //...

    void Update()
    {
        isAirborne.Append( CheckWhetherInTheAir() );
        // Did we just go airborne this update?
        if (isAirborne.RisingEdge)
        {
            // Do stuff for takeoff ...
        }
        else if (isAirborne.FallingEdge)
        {
            // Do stuff for landing ...
        }
    }

#### BooleanSignal TODO
* Make this generic, so it works for ints, floats, etc.
* Add ability to fire events to listeners on state changes
 
