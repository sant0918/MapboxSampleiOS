using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using StateMaps.Models;

namespace StateMaps
{
    public sealed class MapLinkedList
    {
        
        LinkedList<MapLinkedListNode> nodes = new LinkedList<MapLinkedListNode>();
        LinkedListNode<MapLinkedListNode> currentNode;


        public MapLinkedList()
        {
            this.currentNode = new LinkedListNode<MapLinkedListNode>(new MapLinkedListNode(new object { }));
        }

        public void GoToNode(object node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds map tile to link list.
        /// </summary>
        public void AddTile(object tile)
        {
            throw new NotImplementedException();
        }



        public class MapLinkedListNode
        {
            private MapTile _tile;
            
            internal MapLinkedListNode(MapTile tile)
            {
                this._tile = tile;
            }            

        }
    }
}