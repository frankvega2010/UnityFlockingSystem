# UnityFlockingSystem
Flocking system with task prioritization and some steering behaviours. May receive some small updates.

During gameplay you can switch between different cameras by pressing 1-9.
Cameras 1-7 are static , the 8th camera is a Free View camera and the last one switches to a third-person-like view of a boid.

"Boid Manager" is a GameObject which controls all of the system related to Flocking. There you can modify things like the Food Spawner interval and the prefabs for the boids and threats.

![alt text](https://i.imgur.com/ALQp7kT.png)

If you want to modify the properties of the steering behaviours you have to open the "Steering Hehaviours" empty GameObject in the hierarchy
and there you can find all the behaviours that are used in the demo. The Steering Manager takes all the steering behaviours that are in that empty gameObject in the same order as they are in the hierarchy.

![alt text](https://i.imgur.com/FVHQqAp.png)

![alt text](https://i.imgur.com/xmef6ox.png)
