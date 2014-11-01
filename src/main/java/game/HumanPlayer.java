package game;

import java.io.*;

public class HumanPlayer extends Player{

	private String mark;
	private InputStream cin;
	
	public HumanPlayer(String m, InputStream in){
		super(m);
		this.cin = in;
	}
	
	@Override
	public int[] GetMove(){
		println("please enter a x value");
		int x = readInt();
		while(x < 0 || x > 2) {
			System.out.println("Not a valid x value (0-2)");
			x = readInt();
		}
		println("please enter a y value");
		int y = readInt();
		while(y < 0 || y > 2) {
			System.out.println("Not a valid y value (0-2)");
			y = readInt();
		}
		int[] r = new int[2];
		r[0] = x;
		r[1] = y;
		return r;
	}
	
	private void println(String s){
		System.out.println(s);
	}

	private int readInt(){
		try{
			int r = this.cin.read();
			if(r == 32 || r == 10){//we have a space char or newline
				return readInt();
			}
			return r - 48; 
		}catch(IOException i){
			println("read failed");
			return 0;
		}
	}
}
