# RPG-VirtualSticks
Virtual Joystick in Unity for Mobile platforms

Utilizes some free assets from Kenny located here: https://kenney.nl/assets/onscreen-controls

## Using This Library
Currently this library is a work in progress and will be updated as new features are needed for my games. If you would like to use this library in your project you can add this as a submodule to your Unity project. Anywhere within the Assets folder is okay. If you also choose you can download this as a zip and then again manually add all these to a folder in the Assets of your project.

## Current Feature List
- Touch dependant virtual joystick.
- Multiple joysticks being used at once with their own data being sent (Walking, and aiming/shooting for twin stick games)
- Axis data: Get return data from the joystick as a normalized value of -1 to 1 just like a axis on a controller
- Angle data: Get the return data from the joystick as a angle from 0 to 359 where 12 o clock is angle 0 (Great for aiming)
- Updates per frame
- Updates as data change
- On release the knob will return home
- Knob distance can be adjust from 0 to 1 where 1 is the middle of the knob against the background edge
- Knob will let you keep dragging outside of bounds as long as you still have touch input with that specific finger
- Can get the state of the knob if it is currently being used or not
