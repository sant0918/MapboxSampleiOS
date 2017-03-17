using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using StateMaps.Models;

namespace StateMaps
{
    public sealed class MapLinkedList : LinkedList<LinkedListNode<MapTile>>
    {
        
        public LinkedList<LinkedListNode<MapTile>> nodes = new LinkedList<LinkedListNode<MapTile>>();
        public LinkedListNode<MapTile> currentNode;


        public MapLinkedList(MapTile maptile)
        {
            this.currentNode = new LinkedListNode<MapTile>(maptile);
            
        }

        public void GoToNode(object node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Deserialize tile.
        /// </summary>
        public void AddTile(LinkedListNode<MapTile> tile)
        {

            
            // we find the node.
            nodes.Find(tile);
        }


    
    }
}