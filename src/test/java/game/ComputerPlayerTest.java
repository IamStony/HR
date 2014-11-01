package game;

import java.io.*;
import static org.junit.Assert.*;
import org.junit.Test;

public class ComputerPlayerTest{
	public static void main(String args[]){
		org.junit.runner.JUnitCore.main("game.ComputerPlayerTest");
	}

	@Test
	public void testGetMove(){
		ComputerPlayer c = new ComputerPlayer("X", new Board(), "O");
		int[] a = c.GetMove();
		assertNotNull(a);
		assertNotNull(a[0]);
		assertNotNull(a[1]);
	}

}
