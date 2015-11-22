# JabaUnityScripts
Helper scripts for Unity development

BooleanSignal
-

There are often times where you'll want to be able to tell whether some true/false condition changed from false to true or from true to false. Typically, you end up adding pairs of variables for the present and previous values of the condition. BooleanSignal just wraps this so you can add one field of type BooleanSignal, instead of two separate bools.

For example:
    
    private BooleanSignal isAirborne;
    //...
    // Did we start jumping this update?
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
 


