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

Resolution
 - X : 1440, Y : 2960 (Fixed)
