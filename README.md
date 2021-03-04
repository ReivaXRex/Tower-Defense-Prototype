# Project-Tower-Defense
A 3D isometric Tower Defense prototype demonstrating fundamentals of AI pathfinding.

Based off of a section taught from the [Complete Unity C# Developer 3D](https://www.gamedev.tv/p/learn-c-unity-developer-3d-for-video-game-development/?product_id=1503856&coupon_code=JOINUS) course.

A few topics covered within this Section.

- Pathfinding In Unity.
- Unity's NavMesh.
- C# Attributes
- Finding Game Objects By Name
- C# Queues
- Const Variables
- C# Lists & Dictionarys
- Particles Effects
- Unity Post Processing 


### Notes:
[ExecuteInEditMode] - Makes all instances of a script execute in Edit Mode. By default. MonoBehaviors are only executed in Play Mode. By adding this attribute, any instance of the MonoBehavior will have it's callback functions executed when the Editor is not in Play Mode. Functions are not called exactly like they are in Play Mode.

Update is only called when something in the scene changed.
OnGUI is called when the Game View receives an Event.
OnRenderObject every repaint of the Scene View or Game View.


List vs. Array
	Array	List
Size:	Fixed	Variable
Performance:	Easy	Easy
Flexibility:	Low	High
Syntax:	int[]	List<int>

Dictionary
	• Think of it like an index of a book.
	• Keys (words) link to Values (pages).
	• Keys must be unique.
	• Values can be more complex.
Lookup is faster from Key to Value but much slower from Value to Key.
