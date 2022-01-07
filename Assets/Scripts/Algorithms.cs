using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithms : MonoBehaviour
{
    /*
        A-star: 
            * Data structures:
                * visited: list with all visted
                * unvisted: list
                * path: list
                * connections: dictionary of key-nodes value-list of other nodes 
            * Pseudocode:
                * visited is empty
                * path is empty
                * unvisited contains the starting node
                * while not reached goal and unvisited is not empty
                    * take the lowest cost item from the unvisted (put in variable called current)
                    * in connects get all the nodes from current and put it in unvisited
                        * optimaization, if a node is already visited then don't put it in (don't revisit nodes)
                    
    */

    public Dictionary<string, int> x = new Dictionary<string, int>();
    public Dictionary<float, bool> y = new Dictionary<float, bool>();
    public List<HelperClass> z;

    /*
    x = {
        "score": 1,
        "health": 2
    };
    y = {
        1.3f: true,
        3.14f: false 
    };

    int score = x["score"];
    */

    /*
    // A* Search Algorithm from https://www.geeksforgeeks.org/a-search-algorithm/
        1.  Initialize the open list (open == unvisited)
        2.  Initialize the closed list (closed == visited)
            put the starting node on the open 
            list (you can leave its f [total cost] at zero)

        3.  while the open list is not empty
            a) find the node with the least f on 
            the open list, call it "q" (q == current)

            b) pop q off the open list
        
            c) generate q's 8 successors and set their 
            parents to q
        
            d) for each successor
                i) if successor is the goal, stop search
                successor.g = q.g + distance between 
                                    successor and q
                successor.h = distance from goal to 
                successor (This can be done using many 
                ways, we will discuss three heuristics- 
                Manhattan, Diagonal and Euclidean 
                Heuristics)
                
                successor.f = successor.g + successor.h

                ii) if a node with the same position as 
                    successor is in the OPEN list which has a 
                lower f than successor, skip this successor

                iii) if a node with the same position as 
                    successor  is in the CLOSED list which has
                    a lower f than successor, skip this successor
                    otherwise, add  the node to the open list
            end (for loop)
        
            e) push q on the closed list
            end (while loop)
    */


    // Pass by value vs pass by reference

    // x = 10
    // print(addOne(x)) // prints 11
    // print(x) // print 10

    // print(addOneRef(ref x)) // prints 11
    // print(x) // print 11

    public static void Astar<Node>(Node starting, Node goal) where Node: INode
    {
        List<Node> open = new List<Node>();     // Unvisited Nodes
        List<Node> closed = new List<Node>();   // Visited Nodes
        open.Add(starting);

        while(open.Count > 0)
        {
            Node current = open[0];
            foreach (Node n in open)
            {
                if (n.totalCost < current.totalCost)
                {
                    current = n;
                }
            }
            open.Remove(current);
            DetermineNextNodes(goal, ref open, ref closed, current); // TODO: make Node comparable to find lowest node
            closed.Add(current);
            open.Sort(); // TODO: make Node comparable
        }

        
    }

    static void DetermineNextNodes<Node>(Node goal, ref List<Node> open, ref List<Node> closed, Node current) where Node : INode
        {
            foreach (Node successor in current.GetConnection())
            {
                if (successor.IsSameAs(goal))
                {
                    successor.g = current.g;
                    successor.h = 0;
                    successor.totalCost = successor.g + successor.h;
                    continue;
                }
                bool isLowestNode = true;
                foreach (Node n in open)
                {
                    if (n.IsSameAs(successor) && n.totalCost < successor.totalCost)
                    {
                        isLowestNode = false;
                        break;
                    }
                }
                if (!isLowestNode)
                {
                    continue;
                }
                isLowestNode = true;
                foreach (Node n in closed)
                {
                    if (n.IsSameAs(successor))
                    {
                        if (n.totalCost <= successor.totalCost)
                        {
                            isLowestNode = false;
                            break;
                        }
                    }
                }
                open.Add(successor);
            }
        }
    

}

public interface INode{
    public float g{get; set;}
    public float h{get; set;}
    public float totalCost{get; set;}

    public INode[] GetConnection();

    public bool IsSameAs(INode other);
}


[System.Serializable]
public class HelperClass{
    public string something;
    public int other;
}
