using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
	static string moveA;
	static string moveB;
	static int c;
	static int r;
	//static string[] removedTiles;
        static void Main( )
        {
	  //info about game if invalid input/if they want to be in the 
	  //other pawn's position they move back to start
	  //tiles will still be removed even if they lost their turn
	  //if pawn A wants to be where pawn B currently is (or vice versa), pawn A will move 
	  //back to starting position, but when pawn B moves either by making an invalid move and 
	  // moving back to start or making a valid move then A will take up the spot it wanted to 
	  // before automatically
	  
	  Initialization();
	
	  
	    
	    }
        static void Initialization()
	{
	    
	    
	// collects boards rows, column - sets default to 6, 8
	    Write("Enter number of rows: ");
	    
	    string r2 = ReadLine();
	    if(r2.Length == 0) r = 6;
	    else r = int.Parse(r2);
	   
	    Write("Enter number of columns: ");
	    string c2 = ReadLine();

	    if(c2.Length == 0) c = 8;
	    else c = int.Parse(c2);
	   
	   // checks to make sure the input for rows and columns is valid
	    
	    if(4 > r || r> 26) throw new ArgumentOutOfRangeException(nameof(r), "The number must be between 4 and 26");
	    if(4 > c || c> 26) throw new ArgumentOutOfRangeException(nameof(c), "The number must be between 4 and 26");
	    bool [,] board = new bool [r,c];
	    
	    string[ ] letters = { "a","b","c","d","e","f","g","h","i","j","k","l",
                "m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
            
	 // collects users name
	    Write( "Enter your name [default Player A]: " );
	    string name = ReadLine( );
            if( name.Length == 0 ) name = "Player A";
            WriteLine( "name: {0}", name );
	    
	    Write( "Enter your name [default Player B]: " );
            string nameB = ReadLine( );
            if( nameB.Length == 0 ) nameB = "Player B";
            WriteLine( "name: {0}", nameB );
	
	
	    int isTurn = 0;
	   
	    
	    int aRow =2;
	    int aColumn = 0;
	    int bRow = 3;
	    int bColumn = 7;
	    int removedTileRow, removedTileRowB, removedColumn, removedColumnB = 0; 
	    
	    for(int rows = 0; rows<board.GetLength(0); rows++)
	    {
		for(int col = 0; col<board.GetLength(1); col++)
		{
		    board[rows,col] = true;
		
		}
	    }
	    
	    
	// displays board
	    DrawGameBoard(board, aRow, aColumn, bRow, bColumn, isTurn);
	
	
	
	while(isTurn>= 0)
	{
	     if(isTurn%2 == 0)
	    {
	    
	    //gets position starting is 2, 0    
		Write("Enter [abcd] position for "+ name+ ":  ");
		 
		moveA = ReadLine( );
		
	
		int pawnRow = Array.IndexOf( letters,moveA.Substring(0,1));
		removedTileRow =Array.IndexOf( letters, moveA.Substring(2,1));
		
		int pawnColumn= Array.IndexOf(letters,moveA.Substring( 1, 1 ) );
		removedColumn= Array.IndexOf(letters,moveA.Substring( 3, 1 ) );
		    
	    
	    
		board[removedTileRow, removedColumn] = false;
		//checks if they are on board and if tile has already been removed
		//if so they return to starting point
		
		if( pawnRow>r || pawnColumn>c || !board[pawnRow, pawnColumn])
		{
		    WriteLine("Invalid input, tile doesn't exist or removed. Lost turn.");
		    pawnRow = 2; 
		    pawnColumn = 0;
		
		}
		aRow = pawnRow;
		aColumn = pawnColumn;
		DrawGameBoard(board, aRow, aColumn, bRow, bColumn, isTurn);
	    
	    }
	    
	    else
	    {
	      
		
		
	    //  prompt, response platform rows,columns, default  B 3,7
		Write("Enter [abcd] position for "+nameB+ ": ");
		moveB = ReadLine( );
		
		// checks to make sure they're on the board
		    
		   
		    
		
		int pawnRowB = Array.IndexOf( letters,moveB.Substring(0,1));
		removedTileRowB =Array.IndexOf( letters, moveB.Substring(2,1));
	       
		
		int pawnColumnB= Array.IndexOf(letters,moveB.Substring( 1, 1 ) );
		removedColumnB= Array.IndexOf(letters,moveB.Substring( 3, 1 ) );
	      
		 //removes the correct tiles
		 
		    
		    board[removedTileRowB, removedColumnB] = false;
		    
		    //error check to make sure input is not already removed or if the input is on the board
		if( pawnRowB>r || pawnColumnB>c || !board[pawnRowB, pawnColumnB])
		{
		    WriteLine("Invalid input, tile doesn't exist or removed. Lost turn.");
		    pawnRowB = 3; 
		    pawnColumnB = 7;
		
		}
		bRow = pawnRowB;
		bColumn = pawnColumnB;
	    
		DrawGameBoard(board, aRow, aColumn, bRow, bColumn, isTurn);
		
	    }
	
	 isTurn++;   
	
	
	
	}
	 static void DrawGameBoard( bool[,] board, int aRow,int aColumn, int bRow, int bColumn, int isTurn)
        {
	   
	    
	   
            const string h  = "\u2500"; // horizontal line
            const string v  = "\u2502"; // vertical line
            const string tl = "\u250c"; // top left corner
            const string tr = "\u2510"; // top right corner
            const string bl = "\u2514"; // bottom left corner
            const string br = "\u2518"; // bottom right corner
            const string vr = "\u251c"; // vertical join from right
            const string vl = "\u2524"; // vertical join from left
            const string hb = "\u252c"; // horizontal join from below
            const string ha = "\u2534"; // horizontal join from above
            const string hv = "\u253c"; // horizontal vertical cross
	    
	    string bb = " \u25a0 "; // block
	    string rh = "\u2590"; // right half block
	    string fb = "\u2588"; // left half block
	    string lh = "\u258c"; // left half block
            
           string[ ] letters = { "a","b","c","d","e","f","g","h","i","j","k","l",
                "m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
	    
	    // starting position for A and B set to true to display small box
	    
	    
	    board[2, 0] = true;
	    board[3, 7] = true;
	    
	    
		    
	     //check to make sure they aren't taking the same spot if they are move them back to 
	     // staring position
	    if(aRow == bRow && aColumn == bColumn)
	    {
		
		WriteLine("Tile already occupied, Lost turn");
		if(isTurn%2 == 0) 
		{
		    board[aRow, aColumn] = false;
		    aRow = 2; 
		    aColumn = 0;
		    board[bRow, bColumn] = true;
		}
		else 
		{
		    board[bRow, bColumn] = false;
		    bRow = 3;
		    bColumn= 7;
		    board[aRow, aColumn] = true;
		    
		}
	    }
	  
	   
	    
		
	 
            // Draw the top board boundary.
	    Write("     ");
	    for (int c = 0; c<board.GetLength(1); c++){
		Write(letters[c]+"   ");
	    
	    }
	    WriteLine();
            Write( "   " );
            for( int c = 0; c < board.GetLength( 1 ); c ++ )
            {
                if( c == 0) Write( tl );
                Write( "{0}{0}{0}", h );
                if( c == board.GetLength( 1 ) - 1 ) Write( "{0}", tr ); 
                else                                Write( "{0}", hb );
            }
            WriteLine( );
            
	    
            // Draw the board rows.
            for( int r = 0; r < board.GetLength( 0 ); r ++ )
            {
                Write( " {0} ", letters[ r ] );
                
                // Draw the row contents.
                for( int c = 0; c < board.GetLength( 1 ); c ++ )
                {
		   
                    if( c == 0 ) Write( v ); 
		   
		    
		    
		   
		// indicates where pawn A and B are 
		// indicates removed spots
		// indicates starting position
		
		    if(!board[r,c])
		    {
			Write( "{0}{1}", "   " , v);

			
			 
		    }
		    else if(board[r,c])
		    {
			if(aRow == r && aColumn == c)  Write( "{0}{1}"," A " , v );
			else if(bRow ==r && bColumn == c) Write( "{0}{1}"," B " , v ); 
			else if (r == 2 && c == 0) Write( "{0}{1}", bb,v);
			else if( r == 3 && c == 7) Write( "{0}{1}", bb , v );
			else	Write( "{0}{1}{2}{3}", rh, fb, lh, v);
		    }
		   
		
		  
		    
                }
                WriteLine( );
                
                // Draw the boundary after the row.
                if( r != board.GetLength( 0 ) - 1 )
                { 
                    Write( "   " );
                    for( int c = 0; c < board.GetLength( 1 ); c ++ )
                    {
                        if( c == 0 ) Write( vr );
                        Write( "{0}{0}{0}", h );
                        if( c == board.GetLength( 1 ) - 1 ) Write( "{0}", vl ); 
                        else                                Write( "{0}", hv );
                    }
                    WriteLine( );
                }
                else
                {
                    Write("   ");
                    for( int c = 0; c < board.GetLength( 1 ); c ++ )
                    {
                        if( c == 0 ) Write( bl );
                        Write( "{0}{0}{0}", h );
                        if( c == board.GetLength( 1 ) - 1 ) Write( "{0}", br ); 
                        else                                Write( "{0}", ha );
                    }
                    WriteLine( );
                }
		
		
            }
	
	    
        }
    }
}
}

// Graded by: Pascale Walters

/* Initialization (10)
 * + 2/2: Player's name initialization and default behaviour
 * + 2/2: Number of rows on board initialization, default behaviour, and condition check
 * + 2/2: Number of columns on board initialization, default behaviour, and condition check
 * + 1/2: Player A's starting platform initialization, default behaviour, and condition check
 * + 1/2: Player B's starting platform initialization, default behaviour, and condition check
 * Comments:
 * - Ask user for input for starting positions
 *
 * Board state display (10)
 * + 2/2: Each player displays correctly on the board and are distinguishable from one another
 * + 1/2: Each platform displays correctly on the board
 * + 2/2: Removed tiles display correctly on the board
 * + 2/2: Remaining (unremoved) tiles display correctly on the board
 * + 2/2: Rows and columns display nicely with no broken lines, and labels align with rows/columns
 * Comments:
 * - Platform position should not be hard coded
 *
 * Input Parsing (10)
 * + 1/2: Correctly parsing the input in the form of "abcd", where "ab" is the player movement tile and "cd" is the tile to remove
 * + 1/2: Detects if the player movement is valid, and updates the player position if so
 * + 1/2: Detects if the tile to remove is valid, and updates the board to reflect it if so
 * + 2/2: Passes turn to the other player only if the movement and removal are both valid and been updated to the game
 * + 0/2: Prompts the SAME user without passing the turn if invalid input is given, and no changes are updated to the game
 * Comments:
 * - Check if input has 4 letters
 * - Check if pawn move is within one square
 * - Check if tile remove is valid
 * - Player needs to redo turn if their move is invalid
 *
 * Style (6)
 * + 1/1: Reasonable variable names i.e. no "temp", etc.
 * + 1/1: Reasonable variable types i.e. string for name, char/int for row and column, etc.
 * + 2/2: Good commenting
 * + 0/2: Good consistent indentation and spacing
 * Comments:
 * - Lacks consistent spacing
 */

// Grade: 26/36