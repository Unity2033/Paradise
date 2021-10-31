# Game Overview
This is the first Unity project I started, and it is a process of learning and growing many technical elements.

Optimization overview
 - When using coroutines, new WaitForSeconds() is a class, so it was cached and used.
 - Only the UI component that needs to handle the event has enabled the setting of 'Raycast Target'.
 - I set force to mono for each audio clip.
 - The string was used by setting it as a runtime constant.
 - I created Debug as a global class and set the Log global function so that Debug.Log() can be used.
 - CompareTag() is used to compare collisions between objects.
 - Reduced draw calls using sprite atlas.
 - Object pooling is implemented using a list.

SDK Used
 - Unity ADS
 - Google Play Game Service
 - Mobile Notifications
 - Unity Keystore Helper

Game Analysis Program
 - Unity Analysis

Game Sound
 - We used an audio mixer to manage the sound globally.
 - After setting each sound effect as an array, I called it with PlayOneShot().

Design Pattern
 - Singleton

Game Function
 - Localization was done using text files.
 - I used the resize animation of the user interface.
 - The item structure is designed with inheritance.
 - Scriptable objects were used to classify each object.
 - Each time the scene is moved, we used a method to load it into an asynchronous program.
 - Data is stored and managed with PlayerPrefs.
 - After changing position from world space to viewport space, z position was converted into world unit to prevent moving out of the screen.
 - The maximum distance an object can move is specified using distance calculation.
 - Using quaternions, the rotation position of the object is set to a random value between 0 and 360 degrees.
 - The sky box was rotated 360 degrees in real time to give a lively feeling.
 - The vector was normalized for uniform movement of the object.
 - Implemented a pause system using a bool variable.

Resolution
 - X : 1440, Y : 2960 (Fixed)
