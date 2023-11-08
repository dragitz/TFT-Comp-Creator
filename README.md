# TFT Comp Creator

This is a project that I've been working on for a while. With many tests I decided that it was stable enough to be released.

Bug testing is required !

Note: Project uses Newtonsoft.Json, get it in VS by doing: Tools > NuGet Package Manager > Manage NuGet packages for Solution...

![immagine](https://i.imgur.com/wWBXBPt.png)



## Features
* #### Pet algorithm --> Fast hashing

  Hashing is a way to make a unique number, called a "hash," from data. It can be used to quickly compare and find data, which can speed up processes like creating a comp. 
  
  This drastically reduces the compute time and allows the program to produce good and fast results
  

* #### Exclusion / Inclusion
	
    You can specify any desired or unwanted Traits / Champs

*  #### Nodes
	
    The Pet algo uses a list of nodes that represents the "connection" between a champion and another.
    
    It prioritizes the highest "relativeness" to the lowest and the size can be customized in the GUI.
    
    Higher nodes = better results (but also slightly higher computation time)

   Note: Dominant traits with more breakpoints will have a higher impact
    
* #### Filters (main tab)

	I've added a series of filters that increases customization.
    
    Note: the "Disallow unbalanced traits" checkbox will not allow a trait to have a different amount of champions compared to its breakpoints.
    
    	TL;DR: If Trait == Anima Squad (3/5/7) but Trait has a value of 6 (so it's active)
        the comp is considered unbalanced, therefore filtered out.
        
* #### Brute All Champs
	
    Brute force every possible comp

* #### Convert text comp to a valid tftactics.gg team

## Bugs n' stuff
Optimizer tab will not obey to the rules set in the inclusion / exclusion tab

## Design

It sucks I know, but it has never been my objective.

As long as it's minimalistic, I'm happy with it !

## LICENSE

[LICENSE](https://github.com/dragitz/TFT-Comp-Creator/blob/main/LICENSE)
