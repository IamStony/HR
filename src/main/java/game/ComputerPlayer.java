package game;

public class ComputerPlayer extends Player{
	private	int[] moves = {0,2, 2,0, 2,2, 2,1, 1,2, 0,0, 1,0, 0,1, 1,1};
	private	int index;
	private Board bor;
	private String op;

	public ComputerPlayer(String m, Board b, String oponent){
		super(m);
		index = 0;
		bor = b;
		op = oponent;
	}

	private int[] BlockMove(){
		// check horizontal
		for(int i = 0; i < 3; i++){
			if(bor.GetMark(0,i) == op && bor.GetMark(1,i) == op && bor.GetMark(2,i) != this.mark)	return new int[]{2,i}; // X|X| 
			if(bor.GetMark(0,i) == op && bor.GetMark(2,i) == op && bor.GetMark(1,i) != this.mark)	return new int[]{1,i}; // X| |X
			if(bor.GetMark(1,i) == op && bor.GetMark(2,i) == op && bor.GetMark(0,i) != this.mark)	return new int[]{0,i}; // |X|X
		}
		// check vertical
		for(int i = 0; i < 3; i++){
			if(bor.GetMark(i,0) == op && bor.GetMark(i,1) == op && bor.GetMark(i,2) != this.mark) return new int[]{i,2};//bottom
			if(bor.GetMark(i,1) == op && bor.GetMark(i,2) == op && bor.GetMark(i,0) != this.mark) return new int[]{i,0};//top
			if(bor.GetMark(i,0) == op && bor.GetMark(i,2) == op && bor.GetMark(i,1) != this.mark) return new int[]{i,1};//middle
		}

		// check diagonal
		if((bor.GetMark(0,0) == op && bor.GetMark(2,2) == op) || (bor.GetMark(0,2) == op && bor.GetMark(2,0) == op) 
										&& bor.GetMark(1,1) != this.mark) return new int[]{1,1};
		if(bor.GetMark(0,0) == op && bor.GetMark(1,1) == op && bor.GetMark(2,2) != this.mark) return new int[]{2,2};
		if(bor.GetMark(1,1) == op && bor.GetMark(2,2) == op && bor.GetMark(0,0) != this.mark) return new int[]{0,0};
		if(bor.GetMark(1,1) == op && bor.GetMark(0,2) == op && bor.GetMark(2,0) != this.mark) return new int[]{2,0};
		if(bor.GetMark(2,0) == op && bor.GetMark(1,1) == op && bor.GetMark(2,0) != this.mark) return new int[]{2,0};
		return null;
	
	}
	
	public int[] GetMove(){
		int[] a = BlockMove();
		if(a != null){
			return a;
		}
		a = new int[2];
		a[0] = moves[index];
		index++;
		a[1] = moves[index];
		index++;
		return a;
	}

}
