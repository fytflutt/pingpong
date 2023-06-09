# Recent news! 11/2022
The 2022 unite presentation has shown progress on unity's multiplayer abilities, including a built-in process that seems to mimic this approach but in an even better way! That would be rad. Upon its release, this repository may become redundant. 

![cloner](https://user-images.githubusercontent.com/30280876/48310703-37780100-e561-11e8-8319-0ecbaeb8c8e4.gif)
# UnityProjectCloner
A tool to let the user quickly duplicate their unity project *without copying all the assets*, for multiplayer testing

# Why?
One method of quickly debugging multiplayer code is to run multiple unity editors of the same project, and inspect each instance as it works its way through the server/client functions. This is disabled by design for a unity project because of file IO concerns, so this tool lets you get around that by cloning your unity project and creating a series of hard links/junctions in your new cloned folder. These links point back to the original, which can let you edit code and see the results fairly quickly in each cloned unity.

# How?
There's a couple ways you can add this to a unity project:
1. Place this code anywhere in your project!
2. Check this project out somewhere else and point to it with your Unity package manifest:
```"com.hwaet.projectcloner":  "file:../../../../[relative path from your manifest file to the package.json]"```
3. If you've got git installed on your machine, (and unity is > 2018.3.0b7) add a line in your package manifest that points straight here!
```"com.hwaet.projectcloner": "https://github.com/hwaet/UnityProjectCloner.git"```
4. In recent unity versions, you can add the above git link directly in the editor without manually editing your manifest:
![image](https://user-images.githubusercontent.com/30280876/132378040-9d985e3b-634b-46ee-a0c5-5fd52cf37f0b.png)


# Where?
The new cloned project will be placed right next to the original. So your folder structure will look like:
- Root/ProjectName
- Root/ProjectName_clone_0
- Root/ProjectName_clone_1
...

To open the window which allows to create a clone and manage it, in Unity Editor go to "Tools/Project Cloner". After the clone is created, you can launch it from the same window ("Open clone project" button will appear there). No need to add the clone to Unity Hub or anywhere else.

# Future Plans:
- I'm currently using a terminal command to create the folder links instead of kernel32, and that would be much wiser. So that'll be implemented in future passes of this.
- Mac and linux suport would be swell.

# Known Issues:
- When using scriptable objects in one Editor instance, the user will need to trigger a save (either scene or project saves seem to work) in order for the clone to notice that change. Otherwise the scriptable object's values seem to be cached. Save often while you work with SOs!
