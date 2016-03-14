using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    //Juliann Internicola
    //Map Editor V1.0
    //Professor Moreau
    public partial class MapForm : Form
    {
        //global variables
        string water;
        string grass;
        string lava;
        string forest;
        string mountains;
        string sand;
        string empty;
        string eraser;
        int pb_ActiveImage;
        TableLayoutPanel Table;
        Tile[,] tiles;
        Image[] tileImages;
        Random random;
        string mapImageString;
        List<string> mapImageList;
        string[] mapImageArray;

        //Initializes variables and loads them onto the map
        public MapForm()
        {
            InitializeComponent();
            water = (MapVariables.waterImage);
            grass = (MapVariables.grassImage);
            lava = (MapVariables.lavaImage);
            forest = (MapVariables.forestImage);
            mountains = (MapVariables.mountainImage);
            sand = (MapVariables.sandImage);
            empty = (MapVariables.emptyImage);
            eraser = (MapVariables.eraserImage);
            Table = new TableLayoutPanel();
            tiles = new Tile[10, 10];
            tileImages = new Image[7];
            random = new Random();
            mapImageString = null;
            mapImageArray = new string[10];
            mapImageList = new List<string>();
            popTable();
        }

        //Places the images for the tiles into an array.
        public void popTable() 
        {
            tileImages[0] = Image.FromFile("empty.png");
            tileImages[1] = Image.FromFile("forest.png");
            tileImages[2] = Image.FromFile("grass.png");
            tileImages[3] = Image.FromFile("lava.png");
            tileImages[4] = Image.FromFile("mountains.png");
            tileImages[5] = Image.FromFile("sand.png");
            tileImages[6] = Image.FromFile("water.png");

            //For each row and column, add a blank map tile to the table layout; add click event to map tile
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    tiles[row, col] = new Tile(57, 41, tileImages[(int)MapVariables.TileTypes.EMPTY]); 
                    tlp_Map.Controls.Add(tiles[row, col], col, row);
                    tiles[row, col].BringToFront();
                    tiles[row, col].Click += new EventHandler(tile_click);
                }
            }

            tlp_Map.MouseClick += tlp_Map_MouseClick;
        }

        //Depending on the click of the tile, it changes the tile to be clicked on the tlp
        private void tile_click(object sender, EventArgs e)
        {
            Tile numbers = (Tile)sender;

            if (pb_ActiveImage == (int)MapVariables.TileTypes.WATER)
            {
                numbers.Image = Image.FromFile("water.png");
                numbers.pictureId = (int)MapVariables.TileTypes.WATER;
            }
            else if (pb_ActiveImage == (int)MapVariables.TileTypes.GRASS)
            {
                numbers.Image = Image.FromFile("grass.png");
                numbers.pictureId = (int)MapVariables.TileTypes.GRASS;
            }
            else if (pb_ActiveImage == (int)MapVariables.TileTypes.EMPTY)
            {
                numbers.Image = Image.FromFile("empty.png");
                numbers.pictureId = (int)MapVariables.TileTypes.EMPTY;
            }
            else if (pb_ActiveImage == (int)MapVariables.TileTypes.FOREST)
            {
                numbers.Image = Image.FromFile("forest.png");
                numbers.pictureId = (int)MapVariables.TileTypes.FOREST;
            }
            else if (pb_ActiveImage == (int)MapVariables.TileTypes.LAVA)
            {
                numbers.Image = Image.FromFile("lava.png");
                numbers.pictureId = (int)MapVariables.TileTypes.LAVA;
            }
            else if (pb_ActiveImage == (int)MapVariables.TileTypes.MOUNTAINS)
            {
                numbers.Image = Image.FromFile("mountains.png");
                numbers.pictureId = (int)MapVariables.TileTypes.MOUNTAINS;
            }
            else if (pb_ActiveImage == (int)MapVariables.TileTypes.SAND)
            {
                numbers.Image = Image.FromFile("sand.png");
                numbers.pictureId = (int)MapVariables.TileTypes.SAND;
            }
        }

        //Table layout panel mouseclick event
        private void tlp_Map_MouseClick(object sender, MouseEventArgs e)
        {
            int row = 0;
            int verticalOffset = 0;
            foreach (int h in tlp_Map.GetRowHeights())
            {
                int column = 0;
                int horizontalOffset = 0;
                foreach (int w in tlp_Map.GetColumnWidths())
                {
                    Rectangle rectangle = new Rectangle(horizontalOffset, verticalOffset, w, h);
                    if (rectangle.Contains(e.Location))
                    {
                        Console.WriteLine(String.Format("row {0}, column {1} was clicked", row, column));
                        return;
                    }
                    horizontalOffset += w;
                    column++;
                }
                verticalOffset += h;
                row++;
            }
        }

        //Show the Open File dialog. If the user clicks OK, load the map file into the map layout
        private void btn_Load_Click(object sender, EventArgs e)
        {
            string line = "";
            string[] array = new string[10];
            if (File.Exists(tb_UserInput.Text))
            {
                using (StreamReader streamRd = new StreamReader(tb_UserInput.Text))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        line = streamRd.ReadLine();
                        array = line.Split(',');

                        for (int j = 0; j < 10; j++)
                        {
                            tiles[i, j].Image = tileImages[int.Parse(array[j])];
                            tiles[i, j].pictureId = int.Parse(array[j]);
                        }
                    }
                    streamRd.Close();
                }
            }
        }

        //Determines which tile was the last clicked tile.
        public PictureBox getActiveTile()
        {
            return pb_Active;
        }

        //Closes the form.
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Sets the Tiles to an array of 0's
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < 10; row++)
            {

                for (int col = 0; col < 10; col++)
                {
                    this.tiles[row, col].Image = tileImages[(int)MapVariables.TileTypes.EMPTY];
                }
            }
        }


        //Click events for each of the picture boxes
        private void pb_Water_Click(object sender, EventArgs e)
        {
            pb_Active.Image = Image.FromFile("water.png");
            pb_ActiveImage = (int)MapVariables.TileTypes.WATER;
        }

        private void pb_Grass_Click(object sender, EventArgs e)
        {
            pb_Active.Image = Image.FromFile("grass.png");
            pb_ActiveImage = (int)MapVariables.TileTypes.GRASS;
        }

        private void pb_Lava_Click(object sender, EventArgs e)
        {
            pb_Active.Image = Image.FromFile("lava.png");
            pb_ActiveImage = (int)MapVariables.TileTypes.LAVA;
        }

        private void pb_Forest_Click(object sender, EventArgs e)
        {
            pb_Active.Image = Image.FromFile("forest.png");
            pb_ActiveImage = (int)MapVariables.TileTypes.FOREST;
        }

        private void pb_Mountains_Click(object sender, EventArgs e)
        {
            pb_Active.Image = Image.FromFile("mountains.png");
            pb_ActiveImage = (int)MapVariables.TileTypes.MOUNTAINS;
        }

        private void pb_Sand_Click(object sender, EventArgs e)
        {
            pb_Active.Image = Image.FromFile("sand.png");
            pb_ActiveImage = (int)MapVariables.TileTypes.SAND;
        }

        private void pb_Eraser_Click(object sender, EventArgs e)
        {
            pb_Active.Image = Image.FromFile("empty.png");
            pb_ActiveImage = (int)MapVariables.TileTypes.EMPTY;
        }

        private void btn_Randomize_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    int randomNumber = random.Next(1, 7);
                    tiles[row, col].Image = tileImages[randomNumber];
                    tiles[row, col].pictureId = randomNumber;
                }
            }
        }

        //Save Button
        private void btn_Save_Click(object sender, EventArgs e)
        {
            //User Input
            //Works if the New textbox is filled and isn't a bunch of spaces
            if ((tb_UserInput.Text != null) && (!String.IsNullOrWhiteSpace(tb_UserInput.Text)))
            {
                string newFile = tb_UserInput.Text;
                newFile = newFile.Replace(" ", string.Empty); //Gets rid of any spaces in the file name.
                string checkForTxt = ".txt";

                //Checks to see if the file includes the string ".txt" and appends it to the end of the string if it doesn't.
                if (newFile.IndexOf(checkForTxt) == -1)
                    newFile = newFile + ".txt";

            }
            else
            {
                //error message
                MessageBox.Show("Please fill in the textbox.");
            }

            try
            {

                //Text Writer
                StreamWriter strWrite = new StreamWriter(tb_UserInput.Text);
                string write = "";

                for (int i = 0; i < 10; i++)
                {
                    write = "";
                    for (int j = 0; j < 10; j++)
                    {
                        write += tiles[i, j].pictureId + ",";
                    }
                    strWrite.WriteLine(write);
                }
                strWrite.Close();
            }
            catch
            {
                MessageBox.Show("You can't do that.");
            }
            finally
            {
            }
        }
    }
}
