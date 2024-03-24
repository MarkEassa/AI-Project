Hello
This is a group project, which consisted of a mini-game that demonstrates the search techniques in AI

The program loads with a 2D map that shows obstacles located in random blocks on the map, and a pop-up appears with a message saying "PLZ SELECT THE HERO'S POSITION".
And once you click on an empty block with no obstacle on it, the hero is allocated on the position clicked on.

Then another pop up appears with a message saying "PLZ SELECT THE GOAL'S POSITION".
And once you click on an empty block with no obstacle on it (or the hero obviously), the hero is allocated on the position clicked on.

Then, you start the search by clicking one of the following letters on the Keyboard:
B = Breadth-first search technique
D = Depth-first search technique
U = Uniform search technique
A = A* search technique
G = Greedy search technique

Once you click on a letter, the run starts by the hero exploring the unvisited nodes with respect to the obstacles that cannot be visited in it's search tree following the chosen search technique, making the explored nodes blue coloured
And once it finds the goal or the coin, it draws the most suitable path between them in orange then goes to the goal in the end
