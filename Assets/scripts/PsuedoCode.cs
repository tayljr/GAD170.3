/*
Rocket Grenade script:
move forward every frame
function that creates an explosion when this collides with something

Explosion script:
public function that controlls an explosion
create an overlap sphere the detects any objects it touches
for each object the sphere touches ...
... if the object has the player tag then call the impact function on the players script
else add explosion force to object's rigidbodies
destroy this game object at the end

Bananas script:
if enter button pressed and the level is compleated then load next level
if player touches bannas then the level is compleated

Pins script:
add this script to event bus
when event called ...
... destroy previous pin set and create a new one

Game Manager script:
add this script to event bus
when event called ...
... destroy previous pin set and create a new one

Button script:
when this object starts trigger the event on the event bus, activate win popup, deactivate weapon and disable player controller
if the enter button is pushed then deactivate win popup, activate weapon and enable player controller
if player is touching object then increase size of popup to max
if player is touching object and presses e then activate the event on the event bus
if player is not touching object then decreas size of popup to min

Player Movement script changes:
a function to add impact force to the player movement. used for explosions

Event Bus script:
at the start make sure there is only one of these
spawn pins event

Water script:
every frame move water texure

Tutorial script:
if enter button pressed then skip to the end of the video

Gun script:
rotate gun towards pointer
when left mouse button pressed activate shoot function
when R pressed activate reload function
shoot function that checks if the gun is loaded, and if it is loaded then creates a rocket grendade and unloads the gun.
relad function that checks if the gun is not loaded, if it isn't then it loads the gun

Lego script:
when a player enters the trigger, start function with timer
a function with a timer that activates a death screen and waits untill the player presses enter then reloads the scene

Aim script:
point a line from camera center to the mose position
if the ray hits something then set pointer position to the ray hit location
set yaw to mouse x axis, set pitch to mouse y axis while making sure pitch stays within the min and max pitch
rotate object with pitch and yaw

Pick Up script:
set interact popup size to minimum
constat rotaion
if player is touching object then increase size of popup to max
if player is touching object and presses e then activate tutorial, deactivate chactater controller and deactivate itself
if player is not touching object then decreas size of popup to min
when this object is disabled shrink popup to minimum
when video finishes activate the item linked, disable the tutorial and enable the controller 
*/