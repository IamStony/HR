package game;

import static org.junit.Assert.assertEquals;
import org.junit.Test;

public class BoardTest{
	public static void main(String args[]){
		org.junit.runner.JUnitCore.main("game.BoardTest");
	}
		
	@Test
	public void testToString(){
		String line = "-----";
		Board b = new Board();
		String want =	" | | \n" +
				line + "\n" +
				" | | \n" +
				line + "\n" +
				" | | ";
		System.out.println(b.ToString());
		assertEquals(b.ToString(), want);
	}

	@Test
	public void testCanPlaceMark(){
		Board b = new Board();
		for(int x = 0; x < 3; x++){
			for(int y = 0; y < 3; y++){
				assertEquals(b.CanPlaceMark(x, y), true);
			}
		}
	}

	@Test
	public void testPlaceMark(){
		Board b = new Board();
		assertEquals(b.CanPlaceMark(0, 0), true);
		b.PlaceMark("X", 0, 0);
		assertEquals(b.CanPlaceMark(0, 0), false);
		
		//Out of range returns false
		assertEquals(b.CanPlaceMark(9001, 9001), false);
		assertEquals(b.CanPlaceMark(-42, -42), false);
	}

	@Test
        public void testWin(){
        	Board b = new Board();
        	b.PlaceMark("X", 0, 0); //  x | x | x 
        	b.PlaceMark("X", 1, 0); //    |   |  
        	b.PlaceMark("X", 2, 0); //    |   |  
        	assertEquals(b.win(), true);
        	
        	b = new Board();
        	b.PlaceMark("X", 0, 1); //    |   |  
        	b.PlaceMark("X", 1, 1); //  x | x | x 
        	b.PlaceMark("X", 2, 1); //    |   |  
        	assertEquals(b.win(), true);
        	
        	b = new Board();
        	b.PlaceMark("X", 0, 2); //    |   |  
        	b.PlaceMark("X", 1, 2); //    |   |  
        	b.PlaceMark("X", 2, 2); //  x | x | x 
        	assertEquals(b.win(), true);
        	
        	b = new Board();
        	b.PlaceMark("X", 0, 0); //  x |   |  
        	b.PlaceMark("X", 0, 1); //  x |   |  
        	b.PlaceMark("X", 0, 2); //  x |   |   
        	assertEquals(b.win(), true);
        	
        	b = new Board();
        	b.PlaceMark("X", 1, 0); //    | x |  
        	b.PlaceMark("X", 1, 1); //    | x |  
        	b.PlaceMark("X", 1, 2); //    | x |   
        	assertEquals(b.win(), true);
        	
        	b = new Board();
        	b.PlaceMark("X", 2, 0); //    |   | x
        	b.PlaceMark("X", 2, 1); //    |   | x
        	b.PlaceMark("X", 2, 2); //    |   | x 
        	assertEquals(b.win(), true);
        	
        	b = new Board();
        	b.PlaceMark("X", 0, 0); //  x |   |  
        	b.PlaceMark("X", 1, 1); //    | x |  
        	b.PlaceMark("X", 2, 2); //    |   | x 
        	assertEquals(b.win(), true);
        	
        	b = new Board();
        	b.PlaceMark("X", 2, 0); //    |   | x
        	b.PlaceMark("X", 1, 1); //    | x |  
        	b.PlaceMark("X", 0, 2); //  x |   |  
        	assertEquals(b.win(), true);

		b = new Board();
        	assertEquals(b.win(), false);
        	b.PlaceMark("X", 0, 0); //  x |   |  
        	b.PlaceMark("X", 1, 2); //    |   | x
        	b.PlaceMark("X", 2, 1); //    | x |  
        	assertEquals(b.win(), false);
        }

	@Test
        public void testIsFull(){
        	Board b = new Board();
        	assertEquals(b.IsFull(), false);
        	for(int x = 0; x < 3; x++){
        		for(int y = 0; y < 3; y++){
        			b.PlaceMark("X", x, y);
        		}
        	}
        	assertEquals(b.IsFull(), true);
        }

	@Test
	public void testGetMark(){
		Board b = new Board();
		b.PlaceMark("X", 0,0);
		b.PlaceMark("Y", 1,1);
		assertEquals(b.GetMark(0, 0), "X");
		assertEquals(b.GetMark(1, 1), "Y");
		assertEquals(b.GetMark(2, 2), " ");
	}
}
