package game;

import static org.junit.Assert.*;
import org.junit.Test;

	

public class PlayerTest{
	//this class should be empty so we check that it returns nulls
	public static void main(String args[]){
		org.junit.runner.JUnitCore.main("game.PlayerTest");
	}

	@Test
	public void testGetMove(){
		Player p = new Player("X");
		assertNull(p.GetMove());
	}

	@Test
	public void testGetMark(){
		Player p = new Player("X");
		assertEquals(p.GetMark(), "X");
		p = new Player("Y");
		assertEquals(p.GetMark(), "Y");

	}
}
