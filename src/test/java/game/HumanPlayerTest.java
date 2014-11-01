package game;

import java.io.*;
import static org.junit.Assert.*;
import org.junit.Test;

public class HumanPlayerTest{
	public static void main(String args[]){
		org.junit.runner.JUnitCore.main("game.HumanPlayerTest");
	}

	@Test
	public void testGetMove(){
		//ToDo: make custom input stream
		String str = "1 1 0 2";
		InputStream is = new ByteArrayInputStream(str.getBytes());
		HumanPlayer p = new HumanPlayer("X", is);
		int[] a = p.GetMove();
		assertEquals(a[0], 1);
		assertEquals(a[1], 1);
		a = p.GetMove();
		assertEquals(a[0], 0);
		assertEquals(a[1], 2);
	}
}
