using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    //Juliann Internicola
    //Map Editor V1.0
    //Professor Moreau
    
    //Map Variables are referenced throughout the program.
    class MapVariables
    {
        //Tile types have a number set to them.
        public enum TileTypes
        {
            EMPTY = 0,
            FOREST,
            GRASS,
            LAVA,
            MOUNTAINS,
            SAND,
            WATER 
        }

        //Sets the images to a string
        public static string emptyImage = "empty.png";
        public static string eraserImage = "eraser.png";
        public static string forestImage = "forest.png";
        public static string grassImage = "grass.png";
        public static string waterImage = "water.png";
        public static string lavaImage = "lava.png";
        public static string mountainImage = "mountain.png";
        public static string sandImage = "sand.png";  
 
    }
}
