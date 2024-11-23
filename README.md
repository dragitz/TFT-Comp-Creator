# TFT Comp Creator

This is a project that I've been working on for a while. With many tests I decided that it was stable enough to be released.

My goal with this project, is to **compute unique non meta comps** to explore and see how good they might be

Bug testing is required !


![immagine](https://github.com/dragitz/TFT-Comp-Creator/assets/8062792/736a07ad-2265-4ac2-b70c-0413ba75e212)



## Features
* #### n choose k algorithm (no more hashing)
  
  This drastically reduces the compute time and allows the program to produce good and fast results
  

* #### Exclusion / Inclusion
	
    You can specify any desired or unwanted Traits / Champs / Spatula / Headliners

*  #### Nodes
	
    The algo uses a list of nodes that represents the "connection" between a champion and another.
    
    It prioritizes the highest "relativeness" to the lowest and the size can be customized in the GUI.
    
    Higher nodes = better results (but also higher computation time)

   Note: Dominant traits with more breakpoints will have a higher impact
    
* #### Filters (main tab)

	I've added a series of filters that increases customization.
    
    Note: the "Disallow unbalanced traits" checkbox will not allow a trait to have a different amount of champions compared to its breakpoints.
    
    	TL;DR: If Trait == Anima Squad (3/5/7) but Trait has a value of 6 (so it's active)
        the comp is considered unbalanced, therefore filtered out.
        

## Bugs n' stuff


## Design

Not my primary objective, program needs to work !

## LICENSE

[LICENSE](https://github.com/dragitz/TFT-Comp-Creator/blob/main/LICENSE)
